using Microsoft.EntityFrameworkCore;
using WebApplication7.Models;

namespace WebApplication7.Db
{

    public class MydbContext : DbContext
    {
        public  MydbContext(DbContextOptions<MydbContext> options): base(options) { }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoryId);
                entity.Property(e => e.CategoryName);
            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId);
                entity.Property(e => e.ProductName);
                entity.HasOne(e => e.Category)
                .WithMany()
                .HasForeignKey(e => e.CategoryId);




            });
        }

    }

}
