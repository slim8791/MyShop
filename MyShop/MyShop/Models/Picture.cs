namespace MyShop.Models
{
    public class Picture
    {
        public int PictureId { get; set; }
        public string? Content { get; set; }
        public long? DateUpload { get; set; }
        public int? ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
