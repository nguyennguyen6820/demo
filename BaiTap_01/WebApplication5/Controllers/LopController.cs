using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Db;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    [ApiController]
    [Route("api/Lop")]
    public class LopController : ControllerBase
    {
        private readonly MyDbContext db;

        public LopController(MyDbContext dbcontext)
        {
            db = dbcontext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var lops = db.Lop.Include(l => l.SinhViens).ToList();

            
            return Ok(lops);
        }
        [HttpPost]
        public IActionResult Add(Lop lops)
        {
            if(ModelState.IsValid)
            {
                var lop = db.Lop.Find(lops.MaLop);
                if(lop == null)
                {
                    db.Lop.Add(lops);
                    db.SaveChanges();
                    return Ok(lops);
                }
                return BadRequest("lop da ton tai");
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult Update(Lop lops) 
        { 
            if(ModelState.IsValid)
            {
                Lop lop = db.Lop.Find(lops.MaLop);
                if(lop != null)
                {
                    lop.TenLop = lops.TenLop;
                    db.SaveChanges();
                    return Ok(lop);
                }
                return BadRequest("Lop khong ton tai");
            }
            return BadRequest();
        }
        [HttpDelete]
        public IActionResult Delete(string DeleteLop) 
        {
            Lop lop = db.Lop.Find(DeleteLop);
            if(lop != null)
            {
                
                var entity = db.Lop.Remove(lop);
                db.SaveChanges();
                return Ok("da xoa lop: "+ DeleteLop);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("TimLop")]
        public IActionResult TimLop(string timlop)
        {
            Lop lop = db.Lop.Include(l => l.SinhViens).FirstOrDefault(l => l.MaLop == timlop);
                if(lop != null)
            {
                
                return Ok(lop);

            }
            return BadRequest("Lop khong ton tai");
        }
    }
}
