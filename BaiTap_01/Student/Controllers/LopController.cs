using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student.Dtos;
using Student.Db;
using Student.Models;

namespace Student.Controllers
{
    [ApiController]
    [Route("Lop")]
    public class LopController : ControllerBase
    {
        private readonly StudentDbContext _db;
        public LopController(StudentDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var lops = await _db.Lops.ToListAsync();
            
            return Ok(lops);
        }
        [HttpPost]
        public async Task<IActionResult> AddLop(LopDTO dto)
        {
            if (ModelState.IsValid)
            {
                var lop = new Lop { TenLop = dto.TenLop };
                await _db.Lops.AddAsync(lop);
                await _db.SaveChangesAsync();
                return Ok(lop);
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("GetClassByMalop")]
        public async Task<IActionResult> GetClassByMalop(int malop)
        {
            var lop = await _db.Lops.FindAsync(malop);
            if (lop != null)
            {
                var sinhviens = await _db.SinhViens.Where(s => s.MaLop == lop.MaLop).ToListAsync();
                lop.sinhViens = sinhviens;
                return Ok(lop);
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("{malop}")]
        public async Task<IActionResult> Edit(int malop)
        {
            var lop = await _db.Lops.FindAsync(malop);
            return Ok(lop);
        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> Edit(LopDTO dto)
        {
            var lop = await _db.Lops.FindAsync(dto.MaLop);
            if (lop != null)
            {
                lop.TenLop = dto.TenLop;


                await _db.SaveChangesAsync();
                return Ok(lop);

            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(int malop)
        {
            var lop = await _db.Lops.FindAsync(malop);
            if (lop != null)
            {
                _db.Lops.Remove(lop);
                await _db.SaveChangesAsync();
                return Ok(malop);
            }
            return BadRequest();
        }
        


    }
}
