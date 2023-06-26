namespace Bai3.Models
{
    public class OrderItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Picture { get; set; }
        public string OrderId { get; set; } 
        public int Quantity { get; set; }
    }
}
