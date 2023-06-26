using Microsoft.EntityFrameworkCore;
using WebApplication12.Models;

namespace WebApplication12.Db
{
    public class Mydbcontext : DbContext
    {
        public Mydbcontext(DbContextOptions<Mydbcontext>options) : base(options) { }
        public DbSet<Lop> Lops { get; set; }
        public DbSet<SinhVien> SinhViens { get; set; }
    }
}
