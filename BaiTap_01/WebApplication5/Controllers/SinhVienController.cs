using Microsoft.AspNetCore.Mvc;
using WebApplication5.Db;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    [ApiController]
    [Route("api/SinhVien")]
    public class SinhVienController : ControllerBase
    {
        private readonly MyDbContext db1;
        public SinhVienController(MyDbContext dbcontext)
        {
            db1 = dbcontext;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var SV = db1.SinhVien.ToList();
            return Ok(SV);
        }
        [HttpPost]
        public IActionResult Add(SinhVien sinhviens)
        {
            if (ModelState.IsValid)
            {
                var sinhvien = db1.SinhVien.Find(sinhviens.MaSV);
                if (sinhvien == null)
                {
                    db1.SinhVien.Add(sinhviens);
                    db1.SaveChanges();
                    return Ok(sinhviens);

                }
                return BadRequest("Sinh vien da ton tai");
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult SuaSinhVien(SinhVien sinhvien)
        {
            if (ModelState.IsValid)
            {
                SinhVien suasinhvien = db1.SinhVien.Find(sinhvien.MaSV);
                if (suasinhvien != null)
                {
                    suasinhvien.TenSV = sinhvien.TenSV;
                    suasinhvien.NgaySinh = sinhvien.NgaySinh;
                    suasinhvien.GioiTinh = sinhvien.GioiTinh;
                    db1.SaveChanges();
                    return Ok(suasinhvien);
                }
                return BadRequest("Sinh vien khong ton tai");
            }
            return BadRequest();
        }
        [HttpDelete]
        public IActionResult XoaSinhVien(string xoasinhvien)
        {
            SinhVien sinhvienxoa = db1.SinhVien.Find(xoasinhvien);
            if (sinhvienxoa != null)
            {
                db1.SinhVien.Remove(sinhvienxoa);
                db1.SaveChanges();
                return Ok("Da xoa sinh vien: " + xoasinhvien);
            }
            return BadRequest("sinh vien khong ton tai");
        }
        [HttpGet]
        [Route("TimSinhVien")]
        public IActionResult TimSinhVien(string timSinhVien)
        {
            SinhVien timsv = db1.SinhVien.Find(timSinhVien);
            if (timsv != null)
            {
                return Ok(timsv);
            }
            return BadRequest("Sinh vien khong ton tai");
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult LaySinhVienTheoMaLop(string laysv)
        {
            List<SinhVien> laysinhvien = db1.SinhVien.Where(s => s.MaLop == laysv).ToList();
            return Ok(laysinhvien);
        }
    }
}
