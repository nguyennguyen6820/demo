using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaiTap02.Dtos
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(99)]
        public string ProductName { get; set; }
        [Required]
        [MaxLength(1000)]
        public string ProductPicture { get; set; }
        [Required]
        public int CategoryId { get; set; }
        
    }
}
