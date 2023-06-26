using Exam2.Dtos;
using Exam2.Db;
using Microsoft.AspNetCore.Mvc;
using Exam2.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Exam2.Controllers
{
    [Route("api/[COntroller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly StudentDbContext _db;
        public SubjectController(StudentDbContext db)
        {
            _db = db;
        }
        [HttpPost]
        public async Task<IActionResult> Create(SubjectDto dto)
        {
            if (ModelState.IsValid)
            {
                var subject = new Subject { Name = dto.Name, Status = dto.Status };
                await _db.AddAsync(subject);
                await _db.SaveChangesAsync();
                return Ok(subject);
            }
            return BadRequest();

        }
        [HttpGet]
        public async Task<IActionResult> Read()
        {
            var subject = await _db.Subjects.ToListAsync();
            return Ok(subject);
        }
        [HttpPut]
        public async Task<IActionResult> Update(SubjectDto dto)
        {
            if (ModelState.IsValid)
            {
                var subject = await _db.Subjects.FindAsync(dto.Id);
                if(subject != null)
                {
                    subject.Name = dto.Name;
                    subject.Status = dto.Status;
                    await _db.SaveChangesAsync();
                    return Ok(subject);
                }return NotFound();
            }return BadRequest();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var subject = await _db.Subjects.FindAsync(id);
            if(subject != null)
            {
                _db.Subjects.Remove(subject);
                await _db.SaveChangesAsync();
                return Ok(subject);
            }return NotFound(id);
        }
    }
}
