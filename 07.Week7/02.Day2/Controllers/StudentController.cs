using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace WebApplication3.Controllers
{
    [Route("Student")]
    public class StudentController : Controller
    {
        [HttpGet]
        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(String name,int age,String course)
        {
            
                ViewBag.Name = name;
                ViewBag.Age = age;
                ViewBag.Course = course;
                return RedirectToAction("Details", new { Name = name, Age = age, Course = course });
            
           
        }
        [HttpGet("details")]
        public IActionResult Details(string name,int age,string course)
        {
            ViewBag.Name = name;
            ViewBag.Age = age;
            ViewBag.Course = course;
            return View();
        }

    }
}
