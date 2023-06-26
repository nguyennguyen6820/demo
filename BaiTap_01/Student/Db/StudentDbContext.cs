using Microsoft.EntityFrameworkCore;
using Student.Models;

namespace Student.Db
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }
        public DbSet<Lop> Lops { get; set; }
        public DbSet<SinhVien> SinhViens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lop>(entity =>
            {
                entity.HasKey(l => l.MaLop);
                entity.Property(l => l.TenLop)
                .IsRequired()
                .HasMaxLength(11);
                



            });
            modelBuilder.Entity<SinhVien>(entity =>
            {
                entity.HasKey(s => s.MaSV);
                entity.Property(s => s.TenSV)
                .IsRequired()
                .HasMaxLength(50);
                entity.Property(s => s.GioiTinh)
                .IsRequired();
                entity.Property(s => s.NgaySinh)
                .IsRequired();
                entity.HasOne(s => s.Lop)
                .WithMany(s => s.sinhViens)
                .HasForeignKey(s => s.MaLop);

            });
        }
    }
}
