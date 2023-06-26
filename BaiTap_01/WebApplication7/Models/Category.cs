using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models
{
    public class Category
    {
        [Required]
        [Key]
        public string CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public List<Product> Products { get; set; }
    }
}
