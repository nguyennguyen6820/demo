using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Models;
using System.IO;
using System.Text.Json;
using System.Text;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        public static List<Product> Products = new List<Product>();
        [HttpGet]
        public IActionResult Get()
        {
            string a = System.IO.File.ReadAllText("D:/out.txt");
            List<Product> products = new List<Product>();
            products = JsonSerializer.Deserialize<List<Product>>(a);

            return Ok(products);
        }
        [HttpPost]
        public IActionResult Post(Product product)
        {
            Products.Add(product);
            string json = JsonSerializer.Serialize(Products);
            byte[] bytes = Encoding.UTF8.GetBytes(json);
            System.IO.File.WriteAllBytes("D:/out.txt", bytes);
            return Ok(product);
        }
    }
}
