using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

[Route("feedback")]
public class FeedbackController : Controller
{
    
    [HttpGet("form")]
    public IActionResult Form()
    {
        return View();
    }

  
    [HttpPost("submit")]
    public IActionResult Submit(Feedback feedback)
    {
        if (feedback.Rating >= 4)
        {
            ViewData["Message"] = "Thank You for your positive feedback!";
        }
        else
        {
            ViewData["Message"] = "We will improve based on your feedback.";
        }

        ViewData["UserName"] = feedback.Name;

        return View("submit");
    }
}
