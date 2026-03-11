//• Accept employee name, salary and years of experience.
//• Use if-else and conditional operator.
//• Bonus rules:
//   -Experience < 2 years: 5 % bonus
//   - 2 - 5 years: 10 % bonus
//   - > 5 years: 15 % bonus
//• Display final salary after bonus.
//Technical Constraints
//• Use double for salary.
//• Use if-else and ternary operator.
//• Use proper formatting for currency output.

namespace Problem3
{
    internal class Employeebonus
    {
        static void Main(string[] args)
        {
            String name = "";
            double salary = 0.00d;
            float experience = 0.0f;
            Console.WriteLine("enter name:");
            name = Console.ReadLine();
            Console.WriteLine("enter salary:");
            salary =double.Parse( Console.ReadLine());
            Console.WriteLine("enter experience:");
            experience = float.Parse(Console.ReadLine());
            double bonus = 0.0d;
            if(experience>5)
            {
                bonus =salary * 0.15;
            }
            else if (experience > 2 && experience<=5)
            {
                bonus = salary * 0.10;
            }
            else
            {
                bonus = salary * 0.05;

            }

            display finalSalary = (salary > 0 && salary < 0) ? 0 : salary + bonus;
            Console.WriteLine("bonus is:" + bonus);
            Console.WriteLine("final salary is:" + finalSalary);
            Console.ReadLine();

        }
    }
}
