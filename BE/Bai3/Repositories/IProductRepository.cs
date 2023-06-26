using Bai3.Models;

namespace Bai3.Repositories
{
    public interface IProductRepository
    {
        Task<Product> SelectById(int id);
        Task<bool> UpdateQuantity(int id, int quantity);
    }
}
