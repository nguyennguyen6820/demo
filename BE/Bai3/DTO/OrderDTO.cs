using System.ComponentModel.DataAnnotations;

namespace Bai3.DTO
{
    public class OrderDTO
    {
        [Required]
        [MaxLength(40)]
        public string UserId { get; set; }
        public List<OrderItemDTO> Items { get; set; }
    }

    public class OrderItemDTO
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int ProductId { get; set; }
        [Required]
        [Range(1, 50)]
        public int Quantity { get; set; }
    }
}
