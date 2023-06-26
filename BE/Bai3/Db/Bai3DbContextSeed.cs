using Bai3.Models;

namespace Bai3.Db
{
    public class Bai3DbContextSeed
    {
        public async Task SeedAsync(Bai3DbContext context)
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
                new Product { Id = 1, Name = "iPhone 14 Pro Max", Price = 1369.69, Quantity = 15, Picture = "" },
                new Product { Id = 2, Name = "Samsung Glaxy S23", Price = 1100.69, Quantity = 25, Picture = "" },
                new Product { Id = 3, Name = "Xiaomi Mi 13", Price = 966, Quantity = 30, Picture = "" }
            };
        }
    }
}
