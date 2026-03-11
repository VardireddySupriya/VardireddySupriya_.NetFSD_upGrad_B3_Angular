//• Accept student name and marks (0-100).
//• Use if-else statements to determine grade.
//• Display grade as A, B, C, D or Fail.
//• Handle invalid input using conditional checks.
namespace Problem1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String sName = "";
            int marks = 0;
            Console.WriteLine("enter name:");
            sName = Console.ReadLine();
            Console.WriteLine("enter marks:");
            marks = int.Parse(Console.ReadLine());
            if(marks>85)
            {
                Console.WriteLine("Grade:A");
                Console.ReadLine();
            }
            else if (marks > 70 && marks<=85)
            {
                Console.WriteLine("Grade:B");
                Console.ReadLine();
            }
            else if (marks >55 && marks<=70)
            {
                Console.WriteLine("Grade:c");
                Console.ReadLine();
            }
            else if (marks >40 && marks<=55)
            {
                Console.WriteLine("Grade:D");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("fail");
                Console.ReadLine();

            }

        }
    }
}
