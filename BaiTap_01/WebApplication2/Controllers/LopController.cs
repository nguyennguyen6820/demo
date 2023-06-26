using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Db;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class LopController : ControllerBase
    {
        private readonly Mydbcontext _db;
        public  LopController(Mydbcontext dbcontext) 
        {
            _db = dbcontext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            
            var lops = _db.Lop.ToList();
            foreach (var lop in lops)
            {
                var sinhvien = _db.SinhVien.Where(s => s.MaLop == lop.MaLop).ToList();
                lop.SinhViens = sinhvien;
            }
            return Ok(lops);
        }
        [HttpGet]
        [Route("LayRaLopTheoMaLop")]
        public IActionResult LayRaLopTheoMaLop(string malop)
        {
            var layloptheomalop = _db.Lop.Find(malop);
            if (layloptheomalop != null)
            {
                var sinhvien1 = _db.SinhVien.Where(sv => sv.MaLop == malop).ToList();
                layloptheomalop.SinhViens= sinhvien1;
                return Ok(layloptheomalop);
            }
            return BadRequest("Lop khong ton tai");
        }
        [HttpPost]
        public IActionResult Add(Lop lop)
        {
            if(ModelState.IsValid)
            {
                var themlop = _db.Lop.Find(lop.MaLop);
                if(themlop == null)
                {
                    _db.Lop.Add(lop);
                    _db.SaveChanges();
                    return Ok(lop);
                }
                return BadRequest("Lop da ton tai");
            }
            return BadRequest();
        }
        [HttpDelete]
        public IActionResult Delete(string xoa)
        {
            Lop xoalop = _db.Lop.Find(xoa);
            if(xoalop != null)
            {
                var entity = _db.Lop.Remove(xoalop);
                if(entity != null)
                {
                    List<SinhVien> xoasv = _db.SinhVien.Where(x => x.MaLop == xoa).ToList();
                    _db.SinhVien.RemoveRange(xoasv);
                }
                _db.SaveChanges();
                return Ok("Da xoa lop "+ xoa);
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult Put(Lop sua) 
        {
            if(ModelState.IsValid)
            {
                Lop sualop = _db.Lop.Find(sua.MaLop);
                if(sualop != null)
                {
                    sualop.TenLop = sua.TenLop;
                    _db.SaveChanges();
                    return Ok( sualop);

                }
                return BadRequest("Lop khong ton tai");
            }
            return BadRequest();
        }
    }
}
