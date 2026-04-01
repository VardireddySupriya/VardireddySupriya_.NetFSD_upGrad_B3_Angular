using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class StudentRegistration
    {
        [Required]
        public string Name {  get; set; }
        [Range (20,50)]
        public int Age {  get; set; }
        
        public string Course {  get; set; }
    }
}
