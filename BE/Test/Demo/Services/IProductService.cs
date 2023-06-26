using Demo.Dtos;
using Demo.Models;

namespace Demo.Services
{
    public interface IProductService
    {
        Task<Product> AddProduct(Product product);
        Task<ResponseDTO> DeleteProduct(int id);
        Task<ResponseDTO> UpdateProduct(Product prod);
        Task<List<Product>> GetAllProduct();
    }
}
