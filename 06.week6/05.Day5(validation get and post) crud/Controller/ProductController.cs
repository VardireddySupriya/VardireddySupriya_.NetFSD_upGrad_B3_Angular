using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
       
            public static List<Product> products = new List<Product>()
            {
                new Product(){ProductId=1,ProductName="Lamp",Price=800,Category="electronics",quantity=1},
                new Product(){ProductId=2,ProductName="warddrobe",Price=800,Category="furniture",quantity=1},
                new Product(){ProductId=3,ProductName="beds",Price=800,Category="furniture",quantity=1}
            };
        public IActionResult Index()
        {
            return View(products);
        }
        public IActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        
        public IActionResult Create(Product product)
        {
            products.Add(product);

            return RedirectToAction("Index");
        }
        public IActionResult Details(int Id)
        {
           Product proobj=products.FirstOrDefault(Item=>Item.ProductId==Id);
            return View(proobj);
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Product proobj = products.FirstOrDefault(Item => Item.ProductId == Id);
            return View(proobj);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            var exist= products.FirstOrDefault(Item => Item.ProductId == product.ProductId);
            exist.ProductId = product.ProductId;
            exist.ProductName = product.ProductName;
            exist.Price = product.Price;
            exist.Category = product.Category;
            exist.quantity = product.quantity;
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Product proobj = products.FirstOrDefault(Item => Item.ProductId == Id);
            return View(proobj);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int Id)
        {
            Product delete= products.FirstOrDefault(Item => Item.ProductId == Id);
            products.Remove(delete);

            return RedirectToAction("Index");
        }
    }

}
