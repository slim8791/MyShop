namespace MyShop.Models
{
    public class Customer: User
    {
        public string? Picture { get; set; }
        public string? Cin { get; set; }
        public virtual ICollection<OrderCustomer>? OrderCustomer { get; set; }

    }
}
