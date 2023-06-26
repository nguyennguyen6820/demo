using Bai4.Db;
using Bai4.Dtos;
using Bai4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bai4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private Bai4DbContext _db;

        public OrderController(Bai4DbContext db)
        {
            _db = db;
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderDTO dto)
        {
            if(ModelState.IsValid)
            {
                if(dto.Items.Count ==0)
                {
                    return BadRequest("San pham khong co");
                }
                var orderId = Guid.NewGuid().ToString();
                double totalPrices = 0;
                var orderItems = new List<OrderItem>();
                foreach(var item in dto.Items)
                {
                    var product = await _db.Products.FindAsync(item.ProductId);
                    if(product ==null)
                    {
                        return BadRequest("San pham khong ton tai");
                    }
                    if(product.Quantity < item.Quantity)
                    {
                        return BadRequest($"San pham {item.ProductId} khong du");

                    }
                    orderItems.Add(new OrderItem
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = product.Name,
                        OrderId = orderId,
                        Price = product.Price,
                        Quantity = item.Quantity
                    });
                    totalPrices += product.Price *item.Quantity;
                    var order = new Order
                    {
                        Id = orderId,
                        Items = orderItems,
                        TotalPrices = totalPrices
                    };
                    _db.Orders.Add(order);
                    await _db.SaveChangesAsync();
                    return Ok(order);
                }
            }
            return BadRequest();
            
        }

    }
}
