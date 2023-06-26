using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class SanPham
    {
        [Required]
        [Key]
        public string MaSP { get; set; }
        [Required]
        public string TenSP { get; set; }
        [Required]
        public string MaDM { get; set; }
    }
}
