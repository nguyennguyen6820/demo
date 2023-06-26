using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student.Db;
using Student.Dtos;
using Student.Models;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace Student.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class SinhVienController : ControllerBase
    {
        private readonly StudentDbContext _db;
        public SinhVienController(StudentDbContext db)
        {
            _db = db;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var sinhviens = await _db.SinhViens.Include( l => l.Lop).ToListAsync();
            return Ok(sinhviens);
        }
        [HttpPost]
        public async Task<IActionResult> AddSinhVien(SinhVienDTO dto)
        {
            if (ModelState.IsValid)
            {
                var sinhvien = new SinhVien { TenSV = dto.TenSV, GioiTinh = dto.GioiTinh, NgaySinh = dto.NgaySinh, MaLop = dto.MaLop };
                await _db.SinhViens.AddAsync(sinhvien);
                await _db.SaveChangesAsync();
                return Ok(sinhvien);
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("LaySinhVienTheoLop/{malop}")]
        public async Task<IActionResult> LaySinhVienTheoMaLop(int malop)
        {
            List<SinhVien> sinhviens = await _db.SinhViens.Where(sv => sv.MaLop == malop).ToListAsync();
            return Ok(sinhviens);
        }
        [HttpGet]
        [Route("{masv}")]
        public async Task<IActionResult> Edit(int masv)
        {
           var sinhvien = await _db.SinhViens.FindAsync(masv);
            if(sinhvien != null)
            {
                return Ok(sinhvien);

            }
            return BadRequest();
        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> Edit(SinhVienDTO dto)
        {
            var sinhvien = await _db.SinhViens.FindAsync(dto.MaSV);
            if (sinhvien != null)
            {
                sinhvien.TenSV = dto.TenSV;
                sinhvien.GioiTinh = dto.GioiTinh;
                sinhvien.NgaySinh = dto.NgaySinh;
                sinhvien.MaLop = dto.MaLop;

                await _db.SaveChangesAsync();
                return Ok(sinhvien);

            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(int masv)
        {
            var sinhvien = await _db.SinhViens.FindAsync(masv);
            if (sinhvien != null)
            {
                _db.SinhViens.Remove(sinhvien);
                await _db.SaveChangesAsync();
                return Ok(masv);
            }
            return BadRequest();
        }
    }
}
