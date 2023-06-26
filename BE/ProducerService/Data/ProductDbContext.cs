using Microsoft.EntityFrameworkCore;
using ProducerService.Data.Entities;
using ProducerService.Data.EntityTypeConfigurations;

namespace ProducerService.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
