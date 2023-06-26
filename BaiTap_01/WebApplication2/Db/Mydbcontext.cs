using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Db
{
    public class Mydbcontext : DbContext
    {
        public Mydbcontext(DbContextOptions<Mydbcontext> options) : base(options) { }

        public DbSet<Lop> Lop { get; set; }
        public DbSet<SinhVien> SinhVien { get; set; }
    }
}
