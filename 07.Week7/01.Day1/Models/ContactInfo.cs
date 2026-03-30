using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ContactInfo
    {
        [Required]
        public int ContactId {  get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public String CompanyName {  get; set; }
        [EmailAddress]
        public String EmailId { get; set; }

        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Mobile number must be 10 digits")]
        public long MobileNo{ get; set; }
        public string Designation {  get; set; }
    }
}
