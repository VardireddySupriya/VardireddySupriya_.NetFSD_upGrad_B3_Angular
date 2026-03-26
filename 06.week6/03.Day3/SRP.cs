using System;
using System.Collections.Generic;

namespace ConsoleApp4
{
    
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int Marks { get; set; }

        public Student(int id, string name, int marks)
        {
            StudentId = id;
            StudentName = name;
            Marks = marks;
        }
    }


    public class StudentRepository
    {
        private List<Student> students = new List<Student>();

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public List<Student> GetAllStudents()
        {
            return students;
        }
    }

   
    public class ReportGenerator
    {
        public void GenerateReport(List<Student> students)
        {
            Console.WriteLine("----- Student Report -----");
            Console.WriteLine("ID\tName\tMarks\tGrade");

            foreach (var student in students)
            {
                string grade = CalculateGrade(student.Marks);

                Console.WriteLine($"{student.StudentId}\t{student.StudentName}\t{student.Marks}\t{grade}");
            }
        }

        private string CalculateGrade(int marks)
        {
            if (marks >= 90) return "A";
            if (marks >= 75) return "B";
            if (marks >= 50) return "C";
            return "F";
        }
    }

   
    class Program
    {
        static void Main(string[] args)
        {
            // Create repository
            StudentRepository repository = new StudentRepository();
            repository.AddStudent(new Student(1, "Arjun", 85));
            repository.AddStudent(new Student(2, "Meera", 92));
            repository.AddStudent(new Student(3, "Ravi", 48));

            // Generate report
            ReportGenerator reportGenerator = new ReportGenerator();
            reportGenerator.GenerateReport(repository.GetAllStudents());

            Console.ReadLine();
        }
    }
}