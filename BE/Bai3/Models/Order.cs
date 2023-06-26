namespace Bai3.Models
{
    public class Order
    {
        public string Id { get; set; }
        public double TotalPrices { get; set; }
        public  List<OrderItem> Items { get; set;}
    }
}
