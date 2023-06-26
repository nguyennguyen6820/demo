using Bai3.DTO;
using Bai3.Models;

namespace Bai3.Services
{
    public interface IOrderService
    {
        Task<ResponseDTO> AddOrder(OrderDTO orderDTO);
    }
}
