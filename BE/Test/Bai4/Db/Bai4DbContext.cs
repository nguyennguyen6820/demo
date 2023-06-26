using Bai4.Models;
using Microsoft.EntityFrameworkCore;

namespace Bai4.Db
{
    public class Bai4DbContext : DbContext
    {
        public Bai4DbContext(DbContextOptions<Bai4DbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name)
                .HasMaxLength(100);
            });
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.HasMany(p => p.Items)
                .WithOne()
                .HasForeignKey(p => p.OrderId);

            });
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(o => o.Id);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
