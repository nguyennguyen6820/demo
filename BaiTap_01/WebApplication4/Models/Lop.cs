using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Lop
    {
        [Required]
        [Key]
        public string MaLop { get; set; }
        [Required]
        public string TenLop { get; set; }
    }
}
