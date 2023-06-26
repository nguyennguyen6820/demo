using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaiTap_01.Models
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
