using Microsoft.AspNetCore.Mvc;
using WebApplication7.Db;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly MydbContext _db;
        public CategoryController(MydbContext dbcontext)
        {
            _db = dbcontext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var category = _db.Category.ToList();
            return Ok(category);
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            if(ModelState.IsValid)
            {
                var categories = _db.Category.Find(category.CategoryId);
                if(categories == null) 
                {
                    _db.Category.Add(category);
                    _db.SaveChanges();
                    return Ok(category);

                }
                return BadRequest("category already exists");
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("Search")]
        public IActionResult SearchCategory(string  categoryId)
        {
            var searchCategory = _db.Category.Find(categoryId);
            if(searchCategory != null)
            {
                return Ok(searchCategory);
            }
            return NotFound();
        }
        [HttpPut]
        public IActionResult EditCategory(Category category)
        {
            var categori = _db.Category.Find(category.CategoryId);
            if(categori != null)
            {
                categori.CategoryName = category.CategoryName;
                _db.SaveChanges();
                return Ok(categori);
            }
            return NotFound();
        }
        [HttpDelete]
        public IActionResult DeleteCategory(string categoryId) 
        {
            var category = _db.Category.Find(categoryId);
            if(category != null)
            {
                _db.Category.Remove(category);
                _db.SaveChanges();
                return Ok("Deleted category: "+categoryId);
            }
            return NotFound();
        }

    }
}
