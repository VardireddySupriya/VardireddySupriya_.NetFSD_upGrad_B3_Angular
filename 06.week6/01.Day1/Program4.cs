
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
            Console.WriteLine("Order processing started...\n");

            await VerifyPaymentAsync();
            await CheckInventoryAsync();
            await ConfirmOrderAsync();

            Console.WriteLine("\nOrder processing completed successfully!");
            Console.ReadLine();
        }

            static async Task VerifyPaymentAsync()
            {
                Console.WriteLine("Verifying payment...");
                await Task.Delay(3000); 
                Console.WriteLine("Payment verified.");
            }

            static async Task CheckInventoryAsync()
            {
                Console.WriteLine("Checking inventory...");
                await Task.Delay(2000); 
                Console.WriteLine("Inventory available.");
            }

            static async Task ConfirmOrderAsync()
            {
                Console.WriteLine("Confirming order...");
                await Task.Delay(1000); 
                Console.WriteLine("Order confirmed.");
            }
        }
    }








