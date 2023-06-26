using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.DB
{
    public class Mydbcontext : DbContext
    {
        public Mydbcontext(DbContextOptions<Mydbcontext> options) : base(options) { }

        public DbSet<Lop> Lop { get; set; }
        public DbSet<SinhVien> SInhVien { get; set; }
    }
}
