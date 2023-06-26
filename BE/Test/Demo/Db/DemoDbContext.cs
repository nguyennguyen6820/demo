using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Db
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name)
                .IsRequired()
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
