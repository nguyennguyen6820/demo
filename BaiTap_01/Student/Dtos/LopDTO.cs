using Student.Models;
using System.ComponentModel.DataAnnotations;

namespace Student.Dtos
{
    public class LopDTO
    {
        public int MaLop { get; set; }
        [Required]
        [MaxLength(11)]
        public string TenLop { get; set; }
       
    }
}
