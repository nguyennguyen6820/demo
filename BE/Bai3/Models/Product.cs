namespace Bai3.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Picture { get; set; }

        public void DecreaseQuantiy(int quantiy)
        {
            if (quantiy <= 0 || quantiy > Quantity) throw new Exception("So luong ko duoc be hon 0");
            Quantity -= quantiy;
        }

        public void IncreaseQuantiy(int quantiy)
        {
            if (quantiy <= 0) throw new Exception("So luong ko duoc be hon 0");
            Quantity += quantiy;
        }
    }
}
