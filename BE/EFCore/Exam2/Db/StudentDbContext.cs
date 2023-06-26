using Exam2.Models;
using Microsoft.EntityFrameworkCore;

namespace Exam2.Db
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Mark> Marks { get; set; }

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
                .HasMaxLength(250)
                .IsRequired();
                entity.Property(s => s.Birthday)
                .IsRequired();
                entity.Property(s => s.Gender)
                .HasDefaultValue(0);
                entity.Property(s => s.Status)
                .HasDefaultValue(true)
                .IsRequired();
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
                entity.HasKey(m => new {m.StudentId,m.SubjectId});
                entity.HasOne(m => m.Student)
                .WithMany(m =>m.Marks)
                .HasForeignKey(m => m.StudentId);
                entity.HasOne(m => m.Subject)
                .WithMany(m => m.Marks)
                .HasForeignKey(m => m.SubjectId);
                entity.Property(m => m.Scores)
                .IsRequired()
                .HasDefaultValue(0);
                entity.Property(m => m.CreateDate)
                .IsRequired();
            });
            
        }
    }
    
    
}
