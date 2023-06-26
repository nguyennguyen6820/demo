using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Db
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options) { }

        public DbSet<DanhMuc> DanhMuc { get; set; }
        public DbSet<SanPham> SanPham { get; set; }
    }
}
