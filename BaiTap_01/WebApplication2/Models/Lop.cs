using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Lop
    {
        [Required]
        [Key]
        public string MaLop { get; set; }
        [Required]
        public string TenLop { get; set; }
        
        public List<SinhVien> SinhViens { get; set; }
    }
}
