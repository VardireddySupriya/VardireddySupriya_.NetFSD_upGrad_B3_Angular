
using System;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;


namespace ConsoleApp4
{

    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting report generation...\n");

            Task t1 = Task.Run(()=>GenerateSalesReport());
            Task t2 = Task.Run(()=>GenerateInventoryReport());
            Task t3 = Task.Run(()=>GenerateCustomerReport());

            
            await Task.WhenAll(t1, t2, t3);

            Console.WriteLine("\nAll reports generated successfully!");
            Console.ReadLine();
        }

        static void GenerateSalesReport()
        {
            Console.WriteLine("Sales Report started");
            Thread.Sleep(3000);
            Console.WriteLine("Sales Report completed!");
        }

        static void GenerateInventoryReport()
        {
            Console.WriteLine("Inventory Report started");
            Thread.Sleep(4000);
            Console.WriteLine("Inventory Report completed!");
        }

        static void GenerateCustomerReport()
        {
            Console.WriteLine("Customer Report started");
            Thread.Sleep(2000);
            Console.WriteLine("Customer Report completed!");
        }
    }


}





