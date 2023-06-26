using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Models
{
    public class Lop
    {
        [Required]
        [Key]
        public string MaLop { get; set; }
        [Required]
        public string TenLop { get; set; }

        public List<HocSinh> hocSinhs { get; set; }
    }
}
