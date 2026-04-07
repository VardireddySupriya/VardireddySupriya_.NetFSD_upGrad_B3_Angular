using Microsoft.AspNetCore.Mvc;
using WebApplication7.Models;
using WebApplication7.Repository;

namespace WebApplication7.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _repo;

        // Injecting ApplicationDbContext in controller 
        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View(_repo.GetAll());
        }



        public IActionResult Details(int id)
        {
            var prodObj = _repo.GetById(id);
            return View(prodObj);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Products product)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(product);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid Product details.";
                return View();
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var prodObj = _repo.GetById(id);
            return View(prodObj);
        }


        [HttpPost]
        public IActionResult Edit(Products product)
        {

            if (ModelState.IsValid)
            {
                _repo.Update(product);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid Product details.";
                return View();
            }
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var prodObj = _repo.GetById(id);
            return View(prodObj);
        }



        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            var prodObj = _repo.GetById(id);

            if (prodObj != null)
            {
                _repo.Delete(id);
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


