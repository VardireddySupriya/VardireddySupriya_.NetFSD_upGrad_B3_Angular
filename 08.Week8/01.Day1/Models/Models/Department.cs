
using WebApplication7.Models;

namespace WebApplication7.Models

{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public List<ContactInfo> contacts { get; set; }
    }
}

