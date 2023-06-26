using Microsoft.EntityFrameworkCore;
using Bai2.Models;

namespace Bai2.Db
{
    public class MyDbcontext : DbContext
    {
        public MyDbcontext(DbContextOptions<MyDbcontext> options) : base(options) { }
        public DbSet<Student> Student { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Mark> Mark { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {

                entity.ToTable("tbl_student");
                entity.HasKey(s => s.Id);
                entity.Property(s => s.Id)
                .HasColumnName("StudentId");
                entity.Property(s => s.Name)
                .HasColumnName("StudentName")
                .IsRequired()
                .HasMaxLength(250);
                entity.Property(s => s.Birthday)
                .IsRequired();
                entity.Property(s => s.Gender)
                .IsRequired()
                .HasDefaultValue(0);
                entity.Property(s => s.Status)
                .IsRequired()
                .HasDefaultValue(true);
                



            });
            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("tbl_subject");
                entity.HasKey(s => s.Id);
                entity.Property(s => s.Id)
                .HasColumnName("SubjectId");
                entity.Property(s => s.Name)
                .HasColumnName("SubjectName")
                .IsRequired()
                .HasMaxLength(200);
                entity.Property(s => s.Status)
                .IsRequired()
                .HasDefaultValue(true);
                

            });
            modelBuilder.Entity<Mark>(entity =>
            {
                entity.ToTable("tbl_mark");
                entity.HasKey(m => m.Id) ;
                entity.HasOne(m => m.Student)
                    .WithMany(m => m.Marks)
                    .HasForeignKey(m => m.StudentId)
                    .IsRequired();
                entity.HasOne(m => m.Subject)
                    .WithMany(m => m.Marks)
                    .HasForeignKey(m => m.SubjectId)
                    .IsRequired();
                entity.Property(m => m.Scores)
                    .IsRequired()
                    .HasDefaultValue(0);
                entity.Property(m => m.CreateDate)
                    .IsRequired();
            });
        }
    }
}
