using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Demo.Dtos;
using Demo.Services;
namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _orderService;

        public OrderController(IOrderServices orderService)
        {
            _orderService = orderService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderDTO dto)
        {
            if (ModelState.IsValid)
            {
                if (dto.Items.Count == 0)
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
