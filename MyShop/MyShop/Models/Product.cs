namespace MyShop.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Description { get; set; }
        public string Reference { get; set; }
        public double SellPrice { get; set; }
        public double InvoicePrice { get; set; }
        public int Quantity { get; set; }
        public int? SubCategoryId { get; set; }
        public virtual ICollection<Picture>? Pictures { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public virtual ICollection<OrderCustomer>? OrderCustomer { get; set; }
    }
}
