//1.Create a class Student.
//2.Create method CalculateAverage(int m1, int m2, int m3).
//3.Return the average marks.
//4. Display grade based on average.


using System;
using System.Numerics;

namespace ConsoleApp4
{
    internal class Student
    {
        static double CalculateAverage(int a,int b,int c)
        {
            double average =( a + b + c )/ 3.0;
            return average;

        }
       static void showDetails(double average)
        {
            if(average>=80)
            {
                Console.WriteLine($"Average={average}   Grade=A");
            }
            else if (average >= 60)
            {
                Console.WriteLine($"Average={average}   Grade=B");
            }
            else if (average >= 40)
            {
                Console.WriteLine($"Average={average}   Grade=c");
            }
            else
            {
                Console.WriteLine($"Average={average}   Grade=Fail");
            }
        }
        
       

        static void Main(string[] args)
        {
            Console.WriteLine("enter subject1 marks:");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("enter subject2 marks:");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("enter subject3 marks:");
            int c = int.Parse(Console.ReadLine());
            //Console.ReadLine();
            double average1=CalculateAverage(a, b, c);
            showDetails(average1);
            Console.ReadLine();







        }
    }
}
