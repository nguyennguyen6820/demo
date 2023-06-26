using BaiTap2Api.Db;
using BaiTap2Api.Dtos;
using BaiTap2Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaiTap2Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductController : ControllerBase
    {
        private readonly Bai02DbContext _db;

        public ProductController(Bai02DbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _db.Products.Include(p => p.Category).Select(p => new Product {Id=p.Id, ProductName=p.ProductName, CategoryId=p.CategoryId, ProductPicture=p.ProductPicture,Category=p.Category}).ToListAsync();
            return Ok(products);
        }
        [HttpPost]
        public async Task<IActionResult> Index(ProductDTO dto)
        {
            if (ModelState.IsValid)
            {
                var product = new Product {
                    ProductName = dto.ProductName,
                    ProductPicture = dto.ProductPicture,
                    CategoryId = dto.CategoryId
                };
                await _db.Products.AddAsync(product);
                await _db.SaveChangesAsync();
                return Ok(product);
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _db.Products.FindAsync(id);
            return Ok(product);
        }
        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> Edit(ProductDTO dto)
        {
            var product = await _db.Products.FindAsync(dto.Id);
            if (product != null)
            {
                product.ProductName = dto.ProductName; 
                product.ProductPicture = dto.ProductPicture;
                product.CategoryId = dto.CategoryId;

                await _db.SaveChangesAsync();
                return Ok(product);

            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _db.Products.FindAsync(id);
            if (product != null)
            {
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return Ok(product);
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("GetProductByCategoryId")]
        public async Task<IActionResult> GetProductByCategory(int categoryId)
        {
            var product = await _db.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
            return Ok(product);
        }
        [HttpGet]
        [Route("SearchProduct")]
        public async Task<IActionResult> SearchProduct(string productname="")
        {
            if(string.IsNullOrWhiteSpace(productname))
            productname = string.Empty;
            productname = productname.Trim();
            List<Product> product = await _db.Products.Include(p => p.Category).Where(p => p.ProductName.Contains(productname)).Select(p => new Product { Id = p.Id, ProductName = p.ProductName, CategoryId = p.CategoryId, ProductPicture = p.ProductPicture, Category = p.Category }).ToListAsync();
            return Ok(product);

        }



    }
}
