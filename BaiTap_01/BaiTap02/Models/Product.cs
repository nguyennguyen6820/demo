namespace BaiTap02.Models
{
    public class Product
    {
        public string ProductName { get; set; }
        public string ProductPicture { get; set; }
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
