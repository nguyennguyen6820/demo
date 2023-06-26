using Demo.Dtos;
using Demo.Models;
using Demo.Repositories;

namespace Demo.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepo;

        public ProductService(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }
        public async Task<Product> AddProduct(Product prod)
        {
            
            await _productRepo.InsertProduct(prod);
            return prod;
        }
        public async Task<ResponseDTO> DeleteProduct(int id)
        {
            var product = await _productRepo.SelectById(id);
            if(product == null)
            {
                return new ResponseDTO
                {
                    Message = "Product khong ton tai",
                    IsFailed = true
                };
            }
            await _productRepo.DeleteProduct(product);
            return new ResponseDTO
            {
                Message = $"Da xoa product {product.Name}",
                IsFailed = false,
                
            };
        }
        public async Task<ResponseDTO> UpdateProduct(Product prod)
        {
            var product =await _productRepo.SelectById(prod.Id);
            if(product != null)
            {
                product.Name     = prod.Name;
                product.Price    = prod.Price;
                product.Quantity = prod.Quantity;
                product.Picture  = prod.Picture;
                await _productRepo.UpdateProduct(product);
                return new ResponseDTO
                {
                    Data = product
                };
            }
            return new ResponseDTO
            {
                Message = $"San pham {prod.Id} khong ton tai",
                IsFailed = true
            };
        }
        public async Task<List<Product>> GetAllProduct()
        {
            var product = await _productRepo.GetAllProduct();
            return product;
        }
    }
}
