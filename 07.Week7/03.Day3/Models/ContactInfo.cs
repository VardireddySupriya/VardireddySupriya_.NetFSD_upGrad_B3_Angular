using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class ContactInfo
    {
        public  int ContactId {  get; set; }//primary key
        [Required]
        public string FirstName {  get; set; }
        [Required]
        public string LastName { get; set; }
        public string CompanyName {  get; set; }
        [EmailAddress]
        public string EmailId {  get; set; }
        [RegularExpression(@"^[0-9]{10}$",ErrorMessage = "Mobile number must be 10 digits")]
        public long MobileNo {  get; set; }
        public string Designation {  get; set; }
    }
}
