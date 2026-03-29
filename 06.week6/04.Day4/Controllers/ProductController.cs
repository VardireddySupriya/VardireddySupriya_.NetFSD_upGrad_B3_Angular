using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            List<Product> products = new List<Product>()
            {
                new Product(){ProductId=1,ProductName="Lamp",Price=800,Category="electronics",quantity=1},
                new Product(){ProductId=2,ProductName="warddrobe",Price=800,Category="furniture",quantity=1},
                new Product(){ProductId=3,ProductName="beds",Price=800,Category="furniture",quantity=1}
            };
            return View(products);
        }
        public IActionResult Details()
        {
            Product product = new Product() { ProductId = 1, ProductName = "Lamp", Price = 800, Category = "electronics", quantity = 1 };
            return View(product);
        }
    }

}
