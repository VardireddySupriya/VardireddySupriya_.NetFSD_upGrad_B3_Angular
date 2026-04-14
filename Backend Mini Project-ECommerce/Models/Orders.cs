using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_mini_project1.Models
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public Users Users { get; set; }
        public DateTime OrderDate { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalAmount { get; set; }
        public List<OrderItems> OrderItems { get; set; }
    }
}
