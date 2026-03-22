
using System;
using System.IO;

namespace ConsoleApp4
{
    class Program
    {
        static void Main()
        {
           
            static (double salesAmount,int ratings) GetData()
            {
                Console.WriteLine("enter sales amount:");
                double salesAmount = double.Parse(Console.ReadLine());
                Console.WriteLine("enter ratings:");
                int ratings =int.Parse(Console.ReadLine());
                if(salesAmount<=0)
                {
                    Console.WriteLine("enter a valid sales amount.");
                }
                if(ratings <=0 || ratings>5)
                {
                    Console.WriteLine("ratings must between[1-5]");
                }
                return (salesAmount, ratings);

            }
            Console.WriteLine("enter name:");
            string name = Console.ReadLine();
            var (salesAmount, ratings) = GetData();
            string result = (salesAmount, ratings) switch
            {
                ( >= 100000, >= 4) => "high performer",
                ( >= 50000, >= 3) => "Average performer",
                _ => "Needs Improvement"

            };
            
            Console.WriteLine("\n--- Output ---");
            Console.WriteLine($"Employee Name: {name}");
            Console.WriteLine($"Sales Amount: {salesAmount}");
            Console.WriteLine($"Rating: {ratings}");
            Console.WriteLine($"Performance: {result}");
            Console.ReadLine();

        }
    }
}