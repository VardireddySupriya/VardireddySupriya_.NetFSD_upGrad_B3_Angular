namespace backend_mini_project1.Models
{
    public class UserResponseDTO
    {
        public int UserId { get; set; }
        //public Users Users { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
