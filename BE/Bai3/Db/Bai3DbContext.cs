using Bai3.Models;
using Microsoft.EntityFrameworkCore;

namespace Bai3.Db
{
    public class Bai3DbContext : DbContext
    {
        public Bai3DbContext(DbContextOptions<Bai3DbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);
            });
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.HasMany(o => o.Items)
                .WithOne()
                .HasForeignKey(o => o.OrderId);
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
