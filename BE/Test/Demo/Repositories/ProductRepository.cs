using Demo.Db;
using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private DemoDbContext _db;

        public ProductRepository(DemoDbContext db)
        {
            _db = db;
        }
        public async Task<Product> SelectById(int id)
        {
            var product = await _db.Products.FindAsync(id);
            return product;
        }
        public async Task<Product> InsertProduct(Product product)
        {
            _db.Products.Add(product);
            await _db.SaveChangesAsync();
            return product;
        }
        public async Task<Product> DeleteProduct(Product product)
        {
            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
            return product;
        }
        public async Task<Product> UpdateProduct(Product product)
        {
            _db.Update(product);
            await _db.SaveChangesAsync();
            return product;
        }
        public async Task<List<Product>> GetAllProduct()
        {
            var products = await _db.Products.ToListAsync();
            return products;
        }
    }
}
