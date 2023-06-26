using System.ComponentModel.DataAnnotations;

namespace BaiTap_01.Models
{
    public class DanhMuc
    {
        [Required]
        [Key]
        public string MaDM { get; set; }
        [Required]
        public string TenDM { get; set; }
    }
}
