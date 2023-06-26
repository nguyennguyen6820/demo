using System.ComponentModel.DataAnnotations;

namespace WebApplication8.Models
{
    public class NhanVien
    {
        [Required]
        public string MaNV { get; set; }
        [Required]
        public string TenNV { get; set; }

    }
}
