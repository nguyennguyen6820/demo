using System.ComponentModel.DataAnnotations;

namespace WebApplication8.Models
{
    public class PhongBan
    {
        [Required]
        public string MaP { get; set; }
        [Required]
        public string TenP { get; set; }
    }
}
