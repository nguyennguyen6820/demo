using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bai2.Models;
using Bai2.Db;
using Bai2.Dto;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Storage;

namespace Bai2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly MyDbcontext _db;

        public StudentController(MyDbcontext db)
        {
            _db = db;
        }
        [HttpPost]
        public IActionResult Add(Studentdto dto)
        {
            if(ModelState.IsValid)
            {
                var student = new Student()
                {
                    Name = dto.Name,
                    Birthday = dto.Birthday,
                    Gender = dto.Gender,
                    Status = dto.Status
                };
                _db.Student.Add(student);
                _db.SaveChanges();
                return Ok(student);
            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var students = _db.Student.ToList();
            return Ok(students);
        }
        [HttpPut]
        public IActionResult Update(Studentdto dto)
        {
            if(ModelState.IsValid)
            {
                var stud = _db.Student.Find(dto.Id);
                if(stud != null)
                {
                    stud.Name = dto.Name;
                    stud.Birthday = dto.Birthday;
                    stud.Gender = dto.Gender;
                    stud.Status = dto.Status;
                    _db.SaveChanges();
                    return Ok(stud);
                }
                return BadRequest();
            }
            return BadRequest();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var stud = _db.Student.Find(id);
            if(stud != null)
            {
                _db.SaveChanges();
                return Ok(id);
            }return BadRequest("Không tồn tại student: "+id);
        }
        [HttpGet]
        [Route("GetStudentById")]
        public IActionResult GetStudentById(int id)
        {
            var student = _db.Student.Find(id);
            if (student != null)
            {
                var marks = _db.Mark.Where(m => m.StudentId == id)
                    .Select(m => new Mark {StudentId=m.StudentId,SubjectId=m.SubjectId,Scores=m.Scores,CreateDate=m.CreateDate,Id=m.Id })
                    .ToList();
                student.Marks = marks;
                return Ok(student);
            }
            return BadRequest();
        }
        

    }
}
