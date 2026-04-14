using System.ComponentModel.DataAnnotations;

namespace backend_mini_project1.Models
{
    public class ProductDTO
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        public string ImageUrl { get; set; }
    }
}
