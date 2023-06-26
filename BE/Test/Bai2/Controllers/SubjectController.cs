using Bai2.Db;
using Bai2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bai2.Dto;
using Microsoft.EntityFrameworkCore;

namespace Bai2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly MyDbcontext _db;
        public SubjectController(MyDbcontext db)
        {
            _db = db;
        }
        [HttpPost]
        public IActionResult Create(Subjectdto dto)
        {
            if (ModelState.IsValid)
            {
                var subject = new Subject()
                {
                    Name = dto.Name,
                    Status = dto.Status,
                };
                _db.Subject.Add(subject);
                _db.SaveChanges();
                return Ok(subject);
            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult Read()
        {
            var subjects = _db.Subject.ToList();
            return Ok(subjects);
        }
        [HttpPut]
        public IActionResult Update(Subjectdto dto)
        {
            if (ModelState.IsValid)
            {
                var subj = _db.Subject.Find(dto.Id);
                if (subj != null)
                {
                    subj.Name = dto.Name;
                    subj.Status = dto.Status;
                    _db.SaveChanges();
                    return Ok(subj);
                }
                return NotFound();
            }
            return BadRequest();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var subject = _db.Subject.Find(id);
            if (subject != null)
            {
                _db.Remove(subject);
                _db.SaveChanges();
                return Ok(id);
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetSubjectById(int id)
        {
            var subject = _db.Subject.Find(id);
            if (subject != null)
            {
                var mark = _db.Mark.Where(m => m.SubjectId == subject.Id)
                    .Select(m => new Mark
                    {
                        Id = m.Id,
                        StudentId = m.StudentId,
                        SubjectId = m.SubjectId,
                        Scores = m.Scores,
                        CreateDate = m.CreateDate,
                        Student = m.Student
                    })
                    .ToList();

                subject.Marks = mark;
                return Ok(subject);


            }
            return BadRequest();
        }
    }
}
