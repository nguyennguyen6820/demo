using Bai1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Bai1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudController : ControllerBase
    {
        private readonly ModelContext _db;
        public CrudController(ModelContext db)
        {
            _db = db;
        }
        [HttpPost]
        public IActionResult AddCategory(Category category) 
        {
            if(ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                return Ok(category);
            }return BadRequest();
        }
        [HttpGet]
        public IActionResult GetCategory()
        {
            var category = _db.Categories.ToList();
            return Ok(category);
        }
        [HttpPut]
        public IActionResult PutCategory(Category category)
        {
            if(ModelState.IsValid)
            {
                var cate = _db.Categories.Find(category.Id);
                if(cate != null)
                {
                    cate.Id = category.Id;
                    cate.Name = category.Name;
                    cate.Status = category.Status;
                    _db.SaveChanges();
                    return Ok(cate);
                }
                return BadRequest();
            }return BadRequest();
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetCategoryById(decimal id)
        {
            if(id != 0 )
            {
                var cate = _db.Categories.Find(id);
                if(cate != null)
                {
                    return Ok(cate);
                }return NotFound();

            }
            return Ok(_db.Categories);
        }
        [HttpDelete]
        public IActionResult DeleteCategory(decimal id)
        {
            if (id != 0)
            {
                var cate = _db.Categories.Find(id);
                if (cate != null)
                {
                    _db.Categories.Remove(cate);
                    _db.SaveChanges();
                    return Ok(id);
                }
                return NotFound();

            }
            var catego = _db.Categories.ToList();
            _db.Categories.RemoveRange(catego);
            _db.SaveChanges();
            return Ok(catego);
        }
        [HttpPost]
        [Route("Product/CreateProduct")]
        public IActionResult CreateProduct(Product product)
        {
            if(ModelState.IsValid)
            {
                _db.Products.Add(product);
                _db.SaveChanges();
                return Ok(product);
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("Product/ReadProduct")]
        public IActionResult ReadProduct()
        {
            var product = _db.Products.ToList();
            return Ok(product);
        }
        [HttpPut]
        [Route("Product/UpdateProduct")]
        public IActionResult UpdateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                var prod = _db.Products.Find(product.Id);
                if(prod != null)
                {
                    prod.Name = product.Name;
                    prod.Price = product.Price;
                    prod.Status = product.Status;
                    prod.Categoryid = product.Categoryid;
                    prod.Createdate = product.Createdate;
                    _db.SaveChanges();
                    return Ok(prod);

                }
                return NotFound();
            }return BadRequest();
        }
    }
}
