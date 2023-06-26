using Microsoft.AspNetCore.Mvc;
using WebApplication7.Db;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductController : ControllerBase
    {
        private readonly MydbContext _db;
        public ProductController(MydbContext dbcontext)
        {
            _db = dbcontext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _db.Product.ToList();
            return Ok(products);
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if(ModelState.IsValid)
            {
                
                var products = _db.Product.Find(product.ProductId);
                if(products == null)
                {
                    _db.Product.Add(product);
                    _db.SaveChanges();
                    return Ok(product);
                }
                return BadRequest("Product already exists");
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            if(ModelState.IsValid)
            {
                var products = _db.Product.Find(product.ProductId);
                if(products != null)
                {
                    products.ProductName = product.ProductName;
                    products.CategoryId = product.CategoryId;
                    _db.SaveChanges();
                    return Ok(product);
                }
                return NotFound();
            }
            return BadRequest();
        }
        [HttpDelete]
        public IActionResult DeleteProduct(string deleteProduct)
        {
            var delete = _db.Product.Find(deleteProduct);
            if(delete != null)
            {
                _db.Product.Remove(delete);
                _db.SaveChanges();
                return Ok("Da xoa san pham: "+deleteProduct);
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult SearchProduct(string search)
        {
            List<Product> products = _db.Product.Where(p => p.ProductName.Contains(search)).ToList();
            return Ok(products);
        }
    }
}
