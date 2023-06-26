using System.ComponentModel.DataAnnotations;

namespace WebApplication12.Models
{
    public class SinhVien
    {
        [Key]
        public string MaSV { get; set; }
        public string TenSV { get; set; }
        public string MaLop { get; set; }


    }
}
