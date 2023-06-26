using ProducerService.Data.Entities;

namespace ProducerService.Data
{
    public class ProductDbcontextSeed
    {
        public async Task SeedAsync(ProductDbContext context)
        {
            context.Database.EnsureCreated();
            if(!context.Products.Any())
            {
                context.Products.AddRange(GenerateProducts());
                await context.SaveChangesAsync();
            }
        }
        private IEnumerable<Product> GenerateProducts()
        {
            return new List<Product>()
            {
                new Product {Id =1, Name ="Tivi", Price = 500, Quantity = 50, Picture = ""},
                new Product {Id =2, Name ="Tivi", Price = 500, Quantity = 50, Picture = ""},
                new Product {Id =3, Name ="Tivi", Price = 500, Quantity = 50, Picture = ""}
            };
        }
    }
}
