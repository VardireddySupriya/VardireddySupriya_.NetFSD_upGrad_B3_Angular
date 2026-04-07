using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models
{
    public class ContactInfo
    {
        [Key]
        public int ContactId { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [EmailAddress]
        public string EmailId { get; set; }

        [RegularExpression(@"^\d{10}$", ErrorMessage = "Enter valid 10-digit mobile number")]
        public long MobileNo { get; set; }

        public string Designation { get; set; }  // ✅ REMOVE ForeignKey from here

        public int CompanyId { get; set; }

        public int DepartmentId { get; set; }

        [ValidateNever]
        public Company Company { get; set; }

        [ValidateNever]
        public Department Department { get; set; }
    }
}
