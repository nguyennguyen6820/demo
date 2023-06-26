using Demo.Models;
using Demo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost]
        public async Task<IActionResult> CreatProduct(Product prod)
        {
            if(ModelState.IsValid)
            {
                var response = await _productService.AddProduct(prod);
                return Ok(response);
            }
            return BadRequest("Nhap lai");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var respone = await _productService.DeleteProduct(id);
            return Ok(respone);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Product prod)
        {
            if(ModelState.IsValid)
            {
                var response = await _productService.UpdateProduct(prod);
                return Ok(response);
            }
            return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            var response = await _productService.GetAllProduct();
            return Ok(response);
        }
    }
}
