using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class SinhVien
    {
        [Required]
        [Key]
        public string MaSV { get; set; }
        [Required]
        public string TenSV { get; set; }
        [Required]
        public DateTime NgaySinh { get; set; }
        [Required]
        public bool GioiTinh { get; set; }
        [Required]
        public string MaLop { get; set; }
        public Lop Lop { get; set; }
    }
}
