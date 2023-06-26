using Bai3.Models;

namespace Bai3.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> Insert(Order order);
    }
}
