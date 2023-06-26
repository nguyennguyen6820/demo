using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
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
