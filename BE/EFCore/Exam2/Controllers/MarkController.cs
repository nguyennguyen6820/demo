using Exam2.Db;
using Exam2.Dtos;
using Exam2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exam2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkController : ControllerBase
    {
        private readonly StudentDbContext _db;
        public MarkController(StudentDbContext db)
        {
            _db = db;
        }
        [HttpPost]
        public async Task<IActionResult> Create(MarkDto dto)
        {
            if (ModelState.IsValid)
            {
                var mark = new Mark { StudentId = dto.StudentId, SubjectId = dto.SubjectId, Scores = dto.Scores, CreateDate = dto.CreateDate };
                var student = await _db.Students.FindAsync(dto.StudentId);
                var subjec = await _db.Subjects.FindAsync(dto.SubjectId);

                if (student == null || subjec == null)
                {
                    return BadRequest("Student hoac Subject khong ton tai");
                }
                await _db.Marks.AddAsync(mark);
                await _db.SaveChangesAsync();
                return Ok(mark);
            }
            return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> Read()
        {
            var mark = await _db.Marks.ToListAsync();
            return Ok(mark);
        }
        [HttpPut]
        public async Task<IActionResult> Update(MarkDto dto)
        {
            if (ModelState.IsValid)
            {
                var mark = await _db.Marks.FindAsync(dto.StudentId, dto.SubjectId);
                if (mark != null)
                {
                    mark.Scores = dto.Scores;
                    mark.CreateDate = dto.CreateDate;
                    await _db.SaveChangesAsync();
                    return Ok(mark);
                }
                return NotFound();
            }
            return BadRequest();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int Studentid, int subjectid)
        {
            var mark = await _db.Marks.FindAsync(Studentid, subjectid);
            _db.Marks.Remove(mark);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}
