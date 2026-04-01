using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Controllers
{
    public class Product
    {
        [Required]
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int quantity { get; set; }

    }
}
