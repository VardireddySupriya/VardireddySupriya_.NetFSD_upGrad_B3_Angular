using Microsoft.AspNetCore.Mvc;
using WebApplication8.Models;
using WebApplication8.Repository;

namespace WebApplication8.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _repo;
        public StudentController(IStudentRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Students()
        {
            var students= _repo.GetStudentsWithCourses();
            return View(students);

        }
        public IActionResult Courses()
        {
            var courses= _repo.GetCourseWithStudents();
            return View(courses);
        }
    }
}
