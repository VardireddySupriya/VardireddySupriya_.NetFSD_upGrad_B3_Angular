using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Product
    {
        [Required]
        public int ProductId {  get; set; }

        [Required(ErrorMessage = "Product Name is required")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Name must be 5 to 15 characters")]
        public string ProductName{ get; set; }

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }

        [StringLength(15, MinimumLength = 5, ErrorMessage = "Category must be 5 to 15 characters")]
        public string Category {  get; set; }
        public int quantity {  get; set; }
    }
}
