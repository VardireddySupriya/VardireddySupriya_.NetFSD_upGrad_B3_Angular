using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ContactController : Controller
    {
        public static List<ContactInfo> contact=new List<ContactInfo>()
            {
                   new ContactInfo(){ContactId=1,FirstName="John",LastName="Doe",CompanyName="ABC Pvt Ltd",EmailId="john.doe@gmail.com",MobileNo=9876543210,Designation="Manager"},
                   new ContactInfo(){ContactId=2,FirstName="Jane",LastName="Smith",CompanyName="XYZ Ltd",EmailId="jane.smith@gmail.com",MobileNo=9876543211,Designation="Developer"},
                   new ContactInfo(){ContactId=3,FirstName="Robert",LastName="Brown",CompanyName="TechSoft",EmailId="robert.brown@gmail.com",MobileNo=9876543212,Designation="Analyst"},
                   new ContactInfo(){ContactId=4,FirstName="Emily",LastName="Davis",CompanyName="Innovatech",EmailId="emily.davis@gmail.com",MobileNo=9876543213,Designation="Designer"},
                   new ContactInfo(){ContactId=5,FirstName="Michael",LastName="Wilson",CompanyName="NextGen",EmailId="michael.wilson@gmail.com",MobileNo=9876543214,Designation="Team Lead"},
                   new ContactInfo(){ContactId=6,FirstName="Sarah",LastName="Taylor",CompanyName="Alpha Corp",EmailId="sarah.taylor@gmail.com",MobileNo=9876543215,Designation="HR"},
                   new ContactInfo(){ContactId=7,FirstName="David",LastName="Anderson",CompanyName="Beta Solutions",EmailId="david.anderson@gmail.com",MobileNo=9876543216,Designation="Consultant"},
                   new ContactInfo(){ContactId=8,FirstName="Laura",LastName="Thomas",CompanyName="Gamma Ltd",EmailId="laura.thomas@gmail.com",MobileNo=9876543217,Designation="Tester"},
                   new ContactInfo(){ContactId=9,FirstName="Daniel",LastName="Jackson",CompanyName="Delta Inc",EmailId="daniel.jackson@gmail.com",MobileNo=9876543218,Designation="Architect"},
                   new ContactInfo(){ContactId=10,FirstName="Sophia",LastName="White",CompanyName="Epsilon Tech",EmailId="sophia.white@gmail.com",MobileNo=9876543219,Designation="Support"}
            };

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowContacts()
        {
            return View(contact);
        }
        [HttpGet]
        public IActionResult AddContact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddContact(ContactInfo contacts)
        {
            if(ModelState.IsValid)
            {
                contact.Add(contacts);
                return RedirectToAction("Index");

            }
            else
            {
                ViewBag.ErrorMessage = "Invalid data";
                return View();
            }
        }
        public IActionResult GetContactById(int contactId)
        {
            var SearchList = contact.Select(item => item);
            if(contactId != null)
            {
                SearchList=SearchList.Where(item=>item.ContactId == contactId);
            }
            return View(SearchList.ToList());
        }


    }
}
