using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace backend_mini_project1.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [PasswordPropertyText]
        public string Password { get; set; }
        public string Role { get; set; }
        public List<Orders> Orders { get; set; }
    }
}
