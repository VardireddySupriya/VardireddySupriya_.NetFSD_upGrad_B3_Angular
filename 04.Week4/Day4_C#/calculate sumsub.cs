//1.Create a class named Calculator.
//2.Create methods Add(int a, int b) and Subtract(int a, int b).
//3.Each method should return the result.
//4. In Main(), create an object and call the methods.
//5. Display the output.


using System;
using System.Numerics;

namespace ConsoleApp4
{
    internal class Calculate
    {
        int Sum(int a,int b)
        {
            int c = a + b;
            return c;
        }
        int Subtract(int a,int b)
        {
            int c = a - b;
            return c;
        }
       

        static void Main(string[] args)
        {
            Calculate c1 = new Calculate();
            Console.WriteLine("enter first number:");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("enter second number:");
            int b = int.Parse(Console.ReadLine());
            int result=c1.Sum(a,b);
            int result1=c1.Subtract(a,b);
            Console.WriteLine("sum of two numbers is: " + result);
            Console.WriteLine("subtraction of two numbers is: " + result1);
            Console.ReadLine();






        }
    }
}
