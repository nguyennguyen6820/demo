using Bai3.Db;
using Bai3.DTO;
using Bai3.Models;
using Bai3.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bai3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService) 
        {
            _orderService = orderService;
        }
       

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderDTO dto)
        {
            if(ModelState.IsValid)
            {
                if(dto.Items.Count == 0)
                {
                    return BadRequest("Khong co san pham");
                }
                var response = await _orderService.AddOrder(dto);
                if (response.IsFailed)
                    return BadRequest(response.Message);
                return Ok(response);
            }
            return BadRequest();
        }
    }
}
