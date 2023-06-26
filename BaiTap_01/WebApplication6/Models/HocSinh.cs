using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Models
{
    public class HocSinh
    {
        [Required]
        [Key]
        public string MaHS { get; set; }
        [Required]
        public string TenHS { get; set; }
        [Required]
        public DateTime NgaySinh { get; set; }
        [Required]
        public bool GioiTinh { get; set; }
        [Required]
        public string MaLop { get; set; }
    }
}
