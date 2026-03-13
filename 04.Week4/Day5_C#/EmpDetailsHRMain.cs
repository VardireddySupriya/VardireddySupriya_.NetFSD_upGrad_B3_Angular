

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var emp = new EmpDetailsHR("Marko Horvat", 10000m, 35);
            Console.WriteLine(emp.Salary);        // 4500
            emp.GiveRaise(15);                    // OK → 5175
            emp.GiveRaise(40);                    // throws exception (too high)
            emp.FullName = "Marko Horvat Jr.";    // OK
            Console.WriteLine(emp.FullName);      // "Marko Horvat Jr."
            Console.WriteLine(emp.Age);           // 35
        }
    }
}
