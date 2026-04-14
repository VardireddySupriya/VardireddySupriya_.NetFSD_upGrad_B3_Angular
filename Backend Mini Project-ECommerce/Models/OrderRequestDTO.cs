using backend_mini_project1.Controllers;

namespace backend_mini_project1.Models
{
    public class OrderRequestDTO
    {
        public int UserId { get; set; }

        // FIX: prevent "Items field is required"
        public List<OrderItemDTO> Items { get; set; } = new();
    }
}
