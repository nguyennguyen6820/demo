using BaiTap2Api.Models;

using Microsoft.EntityFrameworkCore;

namespace BaiTap2Api.Db
{
    public class Bai02DbContext : DbContext
    {
        public Bai02DbContext(DbContextOptions<Bai02DbContext> options) : base(options) { }
        public DbSet<Category>  Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(c => c.PictureUrl)
                .HasMaxLength(500);
            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.ProductName)
                .IsRequired()
                .HasMaxLength(99);
                entity.Property(p => p.ProductPicture)
                .HasMaxLength(1000);
                entity.HasOne(p => p.Category)
                .WithMany(p =>p.products)
                .HasForeignKey(p => p.CategoryId);
            });
        }

    }
}
