using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class Lop
    {
        [Required]
        public string MaLop { get; set; }
        [Required]
        public string TenLop { get; set; }
        public List<SinhVien> SinhViens { get; set; }
    }
}
