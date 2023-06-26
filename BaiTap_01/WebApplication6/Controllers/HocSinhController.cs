using Microsoft.AspNetCore.Mvc;
using WebApplication6.Db;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    [ApiController]
    [Route("api/HocSinh")]
    public class HocSinhController : ControllerBase
    {
        private readonly Mydbcontext _db;

        public HocSinhController(Mydbcontext mydbcontext)
        {
            _db = mydbcontext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var hocsinh = _db.HocSinh.ToList();
            return Ok(hocsinh);
        }
        [HttpPost]
        public IActionResult Add(HocSinh themhs)
        {
            if(ModelState.IsValid)
            {
                var lop = _db.Lop.Find(themhs.MaLop);
                if(lop == null)
                {
                    return BadRequest("Chua coa lop " + themhs.MaLop);
                }
                var hocsinhthem = _db.HocSinh.Find(themhs.MaHS);
                if(hocsinhthem == null)
                {
                    _db.HocSinh.Add(themhs);
                    _db.SaveChanges();
                    return Ok(themhs);
                }
                return BadRequest("Hoc sinh da ton tai");
            }
            return BadRequest();
        }
        [HttpDelete]
        public IActionResult XoaHocSinh(string xoahs)
        {
            HocSinh hsxoa = _db.HocSinh.Find(xoahs);
            if(hsxoa != null)
            {
                _db.HocSinh.Remove(hsxoa);
                _db.SaveChanges();
                return Ok("da xoa hoc sinh: " + xoahs);
            }
            return BadRequest("Hoc sinh khon ton tai");
        }
        [HttpPut]
        public IActionResult SuaHocSinh(HocSinh suahs)
        {
            if(ModelState.IsValid)
            {
                HocSinh hocsinh = _db.HocSinh.Find(suahs.MaHS);
                if(hocsinh != null)
                {
                    hocsinh.TenHS = suahs.TenHS;
                    hocsinh.NgaySinh = suahs.NgaySinh;
                    hocsinh.GioiTinh = suahs.GioiTinh;
                    hocsinh.MaLop = suahs.MaLop;
                    _db.SaveChanges();
                    return Ok(hocsinh);
                }
                return BadRequest();
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult LayHocSinhTheoMaHS(string mahs)
        {
            var hocsinh = _db.HocSinh.Find(mahs);
            if(hocsinh != null)
            {
                return Ok(hocsinh);
            }
            return BadRequest();
        }
    }
}
