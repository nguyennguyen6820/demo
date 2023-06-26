using Demo.Dtos;

namespace Demo.Services
{
    public interface IOrderServices
    {
        Task<ResponseDTO> AddOrder(OrderDTO orderDTO);
    }
}
