using Dapper;
using Microsoft.Data.SqlClient;
using WebApplication8.Models;

namespace WebApplication8.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly string _conn;

        public StudentRepository(IConfiguration config)
        {
            _conn = config.GetConnectionString("DefaultConnection");
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_conn);
        }

        // Many-to-One: Each Student with their Course
        public IEnumerable<Student> GetStudentsWithCourses()
        {
            using (var db = GetConnection())
            {
                string sql = @"
                    SELECT 
                        s.StudentId, 
                        s.StudentName, 
                        s.CourseId AS StudentCourseId,  -- alias to avoid duplicate column
                        c.CourseId, 
                        c.CourseName
                    FROM Student s
                    INNER JOIN Course c ON s.CourseId = c.CourseId";

                var result = db.Query<Student, Course, Student>(
                    sql,
                    (student, course) =>
                    {
                        student.courses = course;
                        return student;
                    },
                    splitOn: "CourseId"  // first column of second object
                ).ToList();

                return result;
            }
        }

        // One-to-Many: Each Course with its Students
        public IEnumerable<Course> GetCourseWithStudents()
        {
            using (var db = GetConnection())
            {
                string sql = @"
                    SELECT 
                        c.CourseId, 
                        c.CourseName,
                        s.StudentId, 
                        s.StudentName,
                        s.CourseId AS StudentCourseId
                    FROM Course c
                    LEFT JOIN Student s ON c.CourseId = s.CourseId
                    ORDER BY c.CourseId";

                var courseDict = new Dictionary<int, Course>();

                var list = db.Query<Course, Student, Course>(
                    sql,
                    (course, student) =>
                    {
                        if (!courseDict.TryGetValue(course.CourseId, out var currentCourse))
                        {
                            currentCourse = course;
                            currentCourse.Students = new List<Student>();
                            courseDict.Add(course.CourseId, currentCourse);
                        }

                        if (student != null)
                        {
                            currentCourse.Students.Add(student);
                        }

                        return currentCourse;
                    },
                    splitOn: "StudentId"  // first column of the second object
                ).ToList();

                return courseDict.Values;
            }
        }
    }
}