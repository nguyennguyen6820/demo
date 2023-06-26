using Microsoft.AspNetCore.Mvc;
using WebApplication2.Db;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/SinhVien")]
    public class SinhVienController : ControllerBase
    {
        private readonly Mydbcontext db;
        public SinhVienController(Mydbcontext dbsvcontext)
        {
            db = dbsvcontext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var sinhviens = db.SinhVien.ToList();
            return Ok(sinhviens);
        }
        [HttpPost]
        public IActionResult Add(SinhVien sv)
        {
            if(ModelState.IsValid)
            {
                var lop = db.Lop.Find(sv.MaLop);
                if(lop == null)
                {
                    return BadRequest("Lop khong ton tai");
                }
                var themsinhvien = db.SinhVien.Find(sv.MaSV);
                if(themsinhvien == null) 
                {
                    db.SinhVien.Add(sv);
                    db.SaveChanges();
                    return Ok(sv);
                }
                return BadRequest("Sinh vien da ton tai");
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult SuaSinhVien(SinhVien SuaSv)
        {
            if(ModelState.IsValid)
            {
                SinhVien sinhviensua = db.SinhVien.Find(SuaSv.MaSV);
                if(sinhviensua != null)
                {
                    sinhviensua.TenSV = SuaSv.TenSV;
                    sinhviensua.MaLop = SuaSv.MaLop;
                    db.SaveChanges();
                    return Ok(sinhviensua);
                }
                return BadRequest("Sinh Vien khong ton tai");
            }
            return BadRequest();
        }
        [HttpDelete]
        public IActionResult XoaSinhVien(string XoaSv)
        {
            SinhVien sinhvienxoa = db.SinhVien.Find(XoaSv);
            if(sinhvienxoa != null)
                db.SinhVien.Remove(sinhvienxoa);
            db.SaveChanges();
            return Ok(XoaSv);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult LaySinhVienTheoMaLop(string maLop)
        {
            List<SinhVien> laysinhvientheomalop =db.SinhVien.Where(sv => sv.MaLop ==maLop).ToList();
            return Ok(laysinhvientheomalop);

        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult TimSinhVienTheoMaSV(string masv)
        {
            SinhVien timsinhvientheomasv = db.SinhVien.Find(masv);
            if(timsinhvientheomasv != null)
            {
               
                return Ok(timsinhvientheomasv);

            }
            return BadRequest("Sinh vien khong ton tai");
        }
    }
}
