using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace backend_mini_project1.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int Stock { get; set; }
        [JsonIgnore]
        public List<OrderItems> OrderItems { get; set; }
    }
}
