//• Accept two numbers from user.
//• Accept operator (+, -, *, /).
//• Use switch statement to perform operation.
//• Display result.
namespace problem2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int num1 = 0;
            //int num2 = 0;
            //char ch = '';
            Console.WriteLine("enter first number:");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("enter second number:");
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine("enter character:");
            char op = char.Parse(Console.ReadLine());
            int result = 0;
            switch (op){
                case '+':
                    result = num1+num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '*':
                    result = num1 * num2;
                    break;
                case '/':
                    result = num1 /num2;
                    break;
                case '%':
                    result = num1% num2;
                    break;
                default:
                    Console.WriteLine("Invalid operator");
                    Console.ReadLine();
                    return;


            }
            Console.WriteLine("result:" + result);
            Console.ReadLine();



        }
    }
}
