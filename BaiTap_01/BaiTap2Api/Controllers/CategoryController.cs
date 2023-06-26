using BaiTap2Api.Db;
using BaiTap2Api.Dtos;
using BaiTap2Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace BaiTap2Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly Bai02DbContext _db;

        public CategoryController(Bai02DbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _db.Categories.ToListAsync();
            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UpsertCategoryDTO dto)
        {
            if (ModelState.IsValid)
            {
                var category = new Category { Name = dto.Name, PictureUrl = dto.PictureUrl };
                await _db.Categories.AddAsync(category);
                await _db.SaveChangesAsync();
                return Ok(category);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var cat = await _db.Categories.FindAsync(id);
            return Ok(cat);
        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> Edit( UpsertCategoryDTO dto)
        {
            var catOld = await _db.Categories.FindAsync(dto.Id);
            if (catOld != null)
            {
            catOld.Name = dto.Name;
            catOld.PictureUrl = dto.PictureUrl;
            
            await _db.SaveChangesAsync();
            return Ok(catOld);
                
            }
            return BadRequest();
        }
        
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var cate = await _db.Categories.FindAsync(id);
            if(cate != null)
            {
                _db.Categories.Remove(cate);
                await _db.SaveChangesAsync();
                return Ok(id);
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("GetCategoryById")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var cate =await _db.Categories.FindAsync(id);
                if(cate !=null)
            {
                var product = await _db.Products.Where(p => p.CategoryId == cate.Id).Select(p => new Product {Id=p.Id, ProductName=p.ProductName,ProductPicture=p.ProductPicture, CategoryId=p.CategoryId}).ToListAsync();
                cate.products = product;
                
                return Ok(cate);
            }
            return BadRequest();

        }
        


    }
}
