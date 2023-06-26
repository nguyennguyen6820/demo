
using Demo.Dtos;
using Demo.Models;
using Demo.Repositories;
using Oracle.ManagedDataAccess.Types;

namespace Demo.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly IOrderRepository _oderRepo;
        private readonly IProductRepository _productRepo;

        public OrderServices(IOrderRepository oderRepo, IProductRepository productRepo)
        {
            _oderRepo = oderRepo;
            _productRepo = productRepo;
        }
        public async Task<ResponseDTO> AddOrder(OrderDTO orderDTO)
        {
            var orderId = Guid.NewGuid().ToString();
            double totalPrices = 0;
            var orderItems = new List<OrderItem>();
            foreach(var item in orderDTO.Items)
            {
                var product = await _productRepo.SelectById(item.ProductId);
                if(product == null)
                {
                    return new ResponseDTO
                    {
                        Message  = "San pham khong ton tai",
                        IsFailed = true
                    };
                }
                if(product.Quantity < item.Quantity)
                {
                    return new ResponseDTO
                    {
                        Message = $"San pham id {item.ProductId} khong du",
                        IsFailed = true
                    };
                }
                orderItems.Add(new OrderItem
                {
                    Id       = Guid.NewGuid().ToString(),
                    Name     = product.Name,
                    OrderId  = orderId,
                    Price    = product.Price,
                    Quantity = item.Quantity
                });
                totalPrices += product.Price * item.Quantity;
            }
            var oder = new Order
            {
                Id          = orderId,
                Items       = orderItems,
                TotalPrices = totalPrices
            };
            await _oderRepo.Insert(oder);
            return new ResponseDTO
            {
                Data = oder
            };
        }
    }
}
