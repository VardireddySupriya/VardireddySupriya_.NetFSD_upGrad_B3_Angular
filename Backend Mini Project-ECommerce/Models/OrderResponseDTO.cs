namespace backend_mini_project1.Models
{
    public class OrderResponseDTO
    {
        public int OrderId { get; set; }

        public int UserId { get; set; }
        public string UserName { get; set; }  //  IMPORTANT for access control

        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        public string OrderStatus { get; set; } = "Pending"; // optional but useful

        public List<OrderItemResponseDTO> Items { get; set; } = new List<OrderItemResponseDTO>();
    }
}
