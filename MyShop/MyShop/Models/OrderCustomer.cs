namespace MyShop.Models
{
    public class OrderCustomer
    {
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public long Date { get; set; }
    }
}
