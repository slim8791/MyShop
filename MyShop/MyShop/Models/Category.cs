using System.Text.Json.Serialization;

namespace MyShop.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        //[JsonIgnore]
        public string Description { get; set; }
        public virtual ICollection<SubCategory>? SubCategories { get; set; }
    }
}
