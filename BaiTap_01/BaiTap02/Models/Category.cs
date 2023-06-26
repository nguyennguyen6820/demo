namespace BaiTap02.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public List<Product> products { get; set; }
    }
}
