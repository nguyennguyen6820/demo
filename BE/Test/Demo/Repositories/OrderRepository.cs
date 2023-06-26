using Demo.Db;
using Demo.Models;

namespace Demo.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DemoDbContext _db;
        public OrderRepository(DemoDbContext db)
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
