using WebApplication8.Models;

namespace WebApplication8.Repository
{
    public interface IStudentRepository
    {
        public IEnumerable<Student> GetStudentsWithCourses();
        public IEnumerable<Course> GetCourseWithStudents();
    }
}
