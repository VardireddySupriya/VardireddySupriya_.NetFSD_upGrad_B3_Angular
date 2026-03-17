//1.Read array of numbers from the user 
//2.    Send that array to a method :   GetEvenOddCounts()
//3.    int[] GetEvenOddTotals(int[] ar)
//4.Finally display the result in main method

using System;
using System.IO;

namespace ConsoleApp3
{
    internal class Program
    {

        //public record studentDetails(int[] RollNo, String[] Name,String[] Course,int[] marks);
        public static int Divide(int numerator, int denominator)
        {

            return numerator / denominator;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("enter numerator:");
            int numerator = int.Parse(Console.ReadLine());
            Console.WriteLine("enter denominator:");
            int denominator = int.Parse(Console.ReadLine());
            try
            {
                int result = Divide(numerator,denominator);
                Console.WriteLine("Result: " + result);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Cannot divide by zero!");
            }
            finally
            {
                Console.WriteLine("Operation Completed Successfully");
            }


        }




    }


}



