
using System;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;


namespace ConsoleApp4
{

    class Program
    {
        static void Main(string[] args)
        
       {
            try
            {
                Console.Write("Enter Product Name: ");
                string productName = Console.ReadLine();

                Console.Write("Enter Product Price: ");
                double price = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter Discount Percentage: ");
                double discount = Convert.ToDouble(Console.ReadLine());

                double discountAmount = price * discount / 100;
                double finalPrice = price - discountAmount;

                Console.WriteLine("\n--- Bill Details ---");
                Console.WriteLine("Product: " + productName);
                Console.WriteLine("Original Price: " + price);
                Console.WriteLine("Discount: " + discount + "%");
                Console.WriteLine("Final Price: " + finalPrice);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input! Please enter numeric values for price and discount.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("The number entered is too large or too small.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }

            Console.ReadLine();
        }
    }



}

