using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product>();
        [HttpGet("")]
        public IActionResult Details()
        {
            ViewBag.Products = products;
            return View();
        }
     
        
        [HttpPost("add")]
        public IActionResult AddProduct(Product product)
        {
            products.Add(product);

            ViewBag.Products = products;

            return View("Index");
        }
    }

}

