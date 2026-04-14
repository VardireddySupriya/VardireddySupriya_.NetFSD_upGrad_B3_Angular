using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend_mini_project1.Models
{
    public class OrderItems
    {
        [Key]
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public Decimal Price { get; set; }
        [ForeignKey("OrderId")]
        public int OrderId { get; set; }
        [JsonIgnore]
        public Orders Orders { get; set; }
        public int ProductId { get; set; }
        public Products Products { get; set; }
    }
}
