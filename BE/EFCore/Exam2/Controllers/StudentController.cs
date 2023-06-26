using Exam2.Db;
using Exam2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Exam2.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Exam2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbContext _db;
        public StudentController(StudentDbContext db)
        {
            _db = db;
        }
        [HttpPost]
        public async Task<IActionResult> Create(StudentDto dto)
        {
            if (ModelState.IsValid)
            {
                var student = new Student
                {
                    Name = dto.Name,
                    Birthday = dto.Birthday,
                    Gender = dto.Gender,
                    Status = dto.Status

                };
                await _db.Students.AddAsync(student);
                await _db.SaveChangesAsync();
                return Ok(student);
            }
            return BadRequest();
        }
        [HttpGet] 
        public async Task<IActionResult> Read()
        {
            var student = await _db.Students.ToListAsync();
            return Ok(student);
        }
        [HttpPut]
        public async Task<IActionResult> Update(StudentDto dto)
        {
            if (ModelState.IsValid)
            {
                var student = await _db.Students.FindAsync(dto.Id);
                if(student != null)
                {
                    student.Name = dto.Name;
                    student.Birthday = dto.Birthday;
                    student.Gender = dto.Gender;
                    student.Status = dto.Status;
                    await _db.SaveChangesAsync();
                    return Ok(student);
                }return BadRequest();
            }return BadRequest();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _db.Students.FindAsync(id);
                if(student != null)
            {
                _db.Students.Remove(student);
                await _db.SaveChangesAsync();
                return Ok(student);
            }
            return BadRequest();
        }
    }
}
