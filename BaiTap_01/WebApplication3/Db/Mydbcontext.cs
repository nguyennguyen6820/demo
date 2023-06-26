using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Db
{
    public class Mydbcontext : DbContext
    {
        public Mydbcontext(DbContextOptions<Mydbcontext> options ) : base(options) { }
       
        public DbSet<DanhMuc> DanhMuc { get; set; }
        public DbSet<SanPham> SanPham { get; set;}
    }
}
