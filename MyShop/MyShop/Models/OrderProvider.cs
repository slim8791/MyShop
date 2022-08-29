namespace MyShop.Models
{
    public class OrderProvider
    {
        public int ProviderId { get; set; }
        public virtual Provider Provider { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public long Date { get; set; }
    }
}
