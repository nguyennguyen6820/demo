using Bai3.Db;
using Bai3.Models;

namespace Bai3.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly Bai3DbContext _db;

        public ProductRepository(Bai3DbContext db)
        {
            _db = db;
        }

        public async Task<Product> SelectById(int id)
        {
            var product = await _db.Products.FindAsync(id);
            return product;
        }

        public async Task<bool> UpdateQuantity(int id, int quantity)
        {
            var product = await _db.Products.FindAsync(id);
            if (product == null) return false;
            if(quantity > 0)
            {
                product.IncreaseQuantiy(quantity);  
            }
            else
            {
                product.DecreaseQuantiy(-quantity);
            }
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
