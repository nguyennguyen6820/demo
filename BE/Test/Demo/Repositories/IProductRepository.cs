using Demo.Controllers;
using Demo.Models;

namespace Demo.Repositories
{
    public interface IProductRepository
    {
        Task<Product> SelectById(int id);
        Task<Product> InsertProduct(Product product);
        Task<Product> DeleteProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task<List<Product>> GetAllProduct();
    }
}
