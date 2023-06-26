using Bai3.DTO;
using Bai3.Models;
using Bai3.Repositories;

namespace Bai3.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IProductRepository _productRepo;

        public OrderService(IOrderRepository repository, IProductRepository productRepo)
        { 
            _repository = repository;
            _productRepo = productRepo;
        }

        public async Task<ResponseDTO> AddOrder(OrderDTO orderDTO)
        {
            var orderId = Guid.NewGuid().ToString();
            double totalPrices = 0;
            var orderItems = new List<OrderItem>();
            foreach (var item in orderDTO.Items)
            {
                var product = await _productRepo.SelectById(item.ProductId);
                if (product == null)
                {
                    return new ResponseDTO
                    {
                        Message = "Product ko ton tai",
                        IsFailed = true
                    };
                }
                if (product.Quantity < item.Quantity)
                {
                return new ResponseDTO
                    {
                    Message = $"San pham id {item.ProductId} khong du",
                    IsFailed = true
                    };
                }
                orderItems.Add(new OrderItem
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = product.Name,
                    OrderId = orderId,
                    Picture = "",
                    Price = product.Price,
                    Quantity = item.Quantity
                });
                totalPrices += product.Price * item.Quantity;
            }
            foreach(var item in orderDTO.Items) 
            { 
                await _productRepo.UpdateQuantity(item.ProductId, -item.Quantity);
            }
            var order = new Order
            {
                Id = orderId,
                Items = orderItems,
                TotalPrices = totalPrices
            };
            await _repository.Insert(order);
            return new ResponseDTO
            {
                Data = order
            }; 

        }
    }
}
