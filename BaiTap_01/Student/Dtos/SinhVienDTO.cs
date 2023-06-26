using System.ComponentModel.DataAnnotations;

namespace Student.Dtos
{
    public class SinhVienDTO
    {
        public int MaSV { get; set; }
        [Required]
        [MaxLength(50)]
        public string TenSV { get; set; }
        [Required]
        public bool GioiTinh { get; set; }
        [Required]
        public DateTime NgaySinh { get; set; }
        [Required]
        public int MaLop { get; set; }
       
    }
}
