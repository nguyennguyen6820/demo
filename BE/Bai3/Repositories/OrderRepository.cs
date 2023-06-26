using Bai3.Db;
using Bai3.Models;

namespace Bai3.Repositories
{
    public class OrderRepository :
        IOrderRepository
    {
        private readonly Bai3DbContext _db;

        public OrderRepository(Bai3DbContext db)
        {
            _db = db;
        }

        public async Task<Order> Insert(Order order)
        {
            _db.Orders.Add(order);
            await _db.SaveChangesAsync();
            return order;
        }
    }
}
