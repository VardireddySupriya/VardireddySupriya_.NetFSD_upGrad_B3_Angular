using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    [Route("calculator")]
    public class CalculatorController : Controller
    {
        
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        
        [HttpPost("add")]
        public IActionResult Add(int num1, int num2)
        {
            int result = num1 + num2;

            ViewData["Result"] = result;

            return View("Index"); 
        }
    }
}