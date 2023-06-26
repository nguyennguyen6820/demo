using Microsoft.AspNetCore.Mvc;
using WebApplication6.Db;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    [ApiController]
    [Route("api/Lop")]
    public class LopController : ControllerBase
    {
        private readonly Mydbcontext db;

        public LopController(Mydbcontext dbcontext) 
        {
            db = dbcontext;
        
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var lops = db.Lop.ToList();
            foreach(var lop in lops)
            {
                List<HocSinh> hocsinh = db.HocSinh.Where(hs => hs.MaLop == lop.MaLop).ToList();
                lop.hocSinhs = hocsinh;
            }
            
            return Ok(lops);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult LayLopTheoMaLop(string malop)
        {
            var lop = db.Lop.Find(malop);
            if(lop !=null)
            {
                List<HocSinh> hocsinh = db.HocSinh.Where(hs => hs.MaLop == lop.MaLop).ToList();
                lop.hocSinhs = hocsinh;
                return Ok(lop);
            }
            return BadRequest();
        }
        [HttpPost]
        public IActionResult Add(Lop themlop)
        {
            if(ModelState.IsValid)
            {
                var lop = db.Lop.Find(themlop.MaLop);
                if(lop == null)
                {
                    db.Lop.Add(themlop);
                    db.SaveChanges();
                    return Ok(themlop);
                }
                return BadRequest("Lop da ton tai");
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult SuaLop(Lop sualop)
        {
            Lop lop = db.Lop.Find(sualop.MaLop);
            if(lop != null)
            {
               
                lop.TenLop = sualop.TenLop;
                db.SaveChanges();
                return Ok(lop);
            }
            return BadRequest("Lop khong ton tai");
        }
        [HttpDelete]
        public IActionResult XoaLop(string xoalop)
        {
            var xoalp = db.Lop.Find(xoalop);
            if(xoalp != null )
            {
                var entity = db.Lop.Remove(xoalp);
                if (entity != null)
                {
                    List<HocSinh> hocsinh = db.HocSinh.Where(sp => sp.MaLop == xoalop).ToList();
                    db.HocSinh.RemoveRange(hocsinh);

                }
                db.SaveChanges();
                return Ok("Da xoa lop: " + xoalop);
            }
            return BadRequest("Lop khong ton tai");
        }
        

    }
}
