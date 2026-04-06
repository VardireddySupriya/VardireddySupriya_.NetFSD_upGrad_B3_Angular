using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        public IActionResult GetAll()
        {
            var result=_contactService.GetAll();
            return View(result);
        }

        [HttpGet]
        public IActionResult GetByContactId(int id)
        {
            var result = _contactService.GetByContactId(id);
            return View(result);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Add(ContactInfo contact)
        {
           _contactService.Add(contact);
            return RedirectToAction("GetAll");
        }
    }
}
