using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class DanhMuc
    {
        [Required]
        [Key]
        public string MaDM { get; set; }
        [Required]
        public string TenDM { get; set; }
        public List<SanPham> sanPhams { get; set; }
    }
}
