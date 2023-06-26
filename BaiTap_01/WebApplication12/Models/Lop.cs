using System.ComponentModel.DataAnnotations;

namespace WebApplication12.Models
{
    public class Lop
    {
        [Key]
        public string MaLop { get; set; }
        public string TenLop { get; set; }
    }
}
