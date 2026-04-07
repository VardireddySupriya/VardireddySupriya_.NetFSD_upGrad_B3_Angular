using WebApplication7.Models;

namespace WebApplication7.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public List<ContactInfo> ContactInfo { get; set; }
    }
}
