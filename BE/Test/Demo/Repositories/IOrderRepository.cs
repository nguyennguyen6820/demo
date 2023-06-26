using Demo.Models;

namespace Demo.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> Insert(Order order);  
    }
}
