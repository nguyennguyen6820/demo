namespace BaiTap2Api.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductPicture { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
