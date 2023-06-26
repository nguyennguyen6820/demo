using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class SinhVien
    {
        [Required]
        [Key]
        public string MaSV { get; set; }
        [Required]
        public string TenSV { get; set; }
        [Required]
        
        public string MaLop { get; set; }
       
    }
}
