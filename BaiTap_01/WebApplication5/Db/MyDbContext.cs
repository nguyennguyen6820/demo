using WebApplication5.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication5.Db
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Lop> Lop { get; set; }
        public DbSet<SinhVien> SinhVien { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lop>(entity =>
            {
                entity.HasKey(e => e.MaLop);
                entity.Property(e => e.MaLop)
                .HasColumnName("c_ma_lop");
                entity.Property(e => e.TenLop)
                .HasColumnName("c_ten_lop")
                .HasMaxLength(100);
            });

            modelBuilder.Entity<SinhVien>(entity =>
            {
                entity.HasKey(e => e.MaSV);
                entity.HasOne(e => e.Lop)
                .WithMany()
                .HasForeignKey(e => e.MaLop);
            });
        }
    }
}
