using Microsoft.AspNetCore.Mvc;
using WebApplication7.Models;
using WebApplication7.Repository;
using WebApplication7.Services;

namespace WebApplication7.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _service;
        public ContactController(IContactService service)
        {
            _service = service;
        }
        public IActionResult GetAllContacts()
        {
            
            return View(_service.GetAllContacts());
        }
        public IActionResult GetContactById(int id)
        {
            var contact = _service.GetContactById(id);
            if (contact == null)
            {
                ViewBag.Error = "data not found";
                return View();
            }
            return View(contact);

        }
        [HttpGet]
        public IActionResult AddContact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddContact(ContactInfo contact)
        {
            if(ModelState.IsValid)
            {
                 _service.AddContact(contact);
                return RedirectToAction("GetAllContacts");

            }
            else
            {
                ViewBag.ErrorMessage = "not created";
                return View();
            }
        }
        public IActionResult EditContact(int id)
        {
            var edit = _service.GetContactById(id);

            if (edit == null)
            {
                return NotFound();
            }

            return View(edit);
        }

        [HttpPost]
        public IActionResult EditContact(ContactInfo contact)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateContact(contact);
                return RedirectToAction("GetAllContacts");
            }

            ViewBag.Error = "not updated";
            return View(contact);   
        }

        [HttpGet]
        public IActionResult DeleteContact(int id)
        {
            var prodObj = _service.GetContactById(id);
            return View(prodObj);
        }



        [HttpPost]
        [ActionName("DeleteContact")]
        public IActionResult DeleteConfirm(int id)
        {
            var prodObj = _service.GetContactById(id);

            if (prodObj != null)
            {
                _service.DeleteContact(id);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Requested product does not exists";
                return View();
            }
        }
    }
}
