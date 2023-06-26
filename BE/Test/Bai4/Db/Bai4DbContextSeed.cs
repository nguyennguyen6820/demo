using Bai4.Models;

namespace Bai4.Db
{
    public class Bai4DbContextSeed
    {
        public async Task SeedAsync(Bai4DbContext context)
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
                new Product {Id = 1 ,Name="Tivi", Price = 501, Quantity = 50, Picture="" },
                new Product {Id = 2 ,Name="Tu lanh", Price = 400.33, Quantity = 50, Picture="" },
                new Product {Id = 3 ,Name="May Giat", Price = 222.4, Quantity = 50, Picture="" },
                new Product {Id = 4 ,Name="Lo", Price = 501, Quantity = 50, Picture="" }
            };

        }
    }
}

