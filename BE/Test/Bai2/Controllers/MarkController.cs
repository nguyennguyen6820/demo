using Bai2.Db;
using Bai2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bai2.Dto;

namespace Bai2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkController : ControllerBase
    {
        private readonly MyDbcontext _db;
        public MarkController(MyDbcontext db)
        {
            _db = db;
        }
        [HttpPost]
        public IActionResult Create(Markdto dto)
        {
            if(ModelState.IsValid)
            {
                var mark = new Mark()
                {
                    StudentId = dto.StudentId,
                    SubjectId = dto.SubjectId,
                    Scores = dto.Scores,
                    CreateDate =dto.CreateDate,
                };
                _db.Mark.Add(mark);
                _db.SaveChanges();
                return Ok(mark);
            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult Read()
        {
            var marks = _db.Mark.ToList();
            return Ok(marks);
        }
        [HttpPut] 
        public IActionResult Update(Markdto dto)
        {
            if(ModelState.IsValid)
            {
                var mark = _db.Mark.Find(dto.Id);
                if(mark != null)
                {
                    mark.StudentId = dto.StudentId;
                    mark.SubjectId = dto.SubjectId;
                    mark.Scores = dto.Scores;
                    mark.CreateDate = dto.CreateDate;
                    _db.SaveChanges();
                    return Ok(mark);
                }return NotFound();
            }return BadRequest();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var mark = _db.Mark.Find(id);
            if(mark != null)
            {
                _db.Mark.Remove(mark);
                _db.SaveChanges();
                return Ok(id);
            }return BadRequest("Không tồn tại");
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetMarkByStudentId(int studentid)
        {
            List<Mark> mark = _db.Mark.Where(m => m.StudentId == studentid).ToList();
            return Ok(mark);
        }
        
    }
}
