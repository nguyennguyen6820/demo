using Microsoft.EntityFrameworkCore;
using WebApplication6.Models;

namespace WebApplication6.Db
{
    public class Mydbcontext : DbContext
    {
        public Mydbcontext(DbContextOptions<Mydbcontext> options): base(options) { }

        public DbSet<Lop> Lop { get; set; }
        public DbSet<HocSinh> HocSinh { get; set;}
    }
}
