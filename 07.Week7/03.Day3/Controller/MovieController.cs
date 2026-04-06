using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MovieController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult GetAll()
        {
            var movies = _context.Movies.ToList();
            return View(movies);
        }
        public IActionResult Details(int id)
        {
            var prodObj = _context.Movies.Find(id);
            return View(prodObj);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                var create = _context.Movies.Add(movie);
                _context.SaveChanges();
                return RedirectToAction("GetAll");
            }
            else
            {
                ViewBag.ErrorMessage = "not created";
                return View();
            }

        }
        public IActionResult Edit(Movie movie)
        {

            if (ModelState.IsValid)
            {
                _context.Movies.Update(movie);     // Create
                _context.SaveChanges();             // Update to Database
                return RedirectToAction("GetAll");
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
            var prodObj = _context.Movies.Find(id);
            return View(prodObj);
        }



        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            var prodObj = _context.Movies.Find(id);

            if (prodObj != null)
            {
                _context.Movies.Remove(prodObj);
                _context.SaveChanges();
                return RedirectToAction("GetAll");
            }
            else
            {
                ViewBag.ErrorMessage = "Requested product does not exists";
                return View();
            }
        }
    }
}
