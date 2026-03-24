
using System;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;


namespace ConsoleApp4
{

    class Program
    {
        static SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
        static async Task Main()
        {
            
            Console.WriteLine("start logging");
            List<Task<string>> tasks= new List<Task<string>>();
            for(int i=0;i<3;i++)
            {
                string message=($"hello world-----tasks{i}-------{DateTime.Now}");
                tasks.Add(WriteLogAsync(message));
            }
            string[] results = await Task.WhenAll(tasks);
            Console.WriteLine("logs executed simultaneously");

            Console.WriteLine("\nAll logs completed:");
            foreach (var res in results)
            {
                Console.WriteLine(res);
            }

            Console.ReadLine();
           
        }
        static async Task<string> WriteLogAsync(string message)
        {
            await semaphore.WaitAsync();
            try
            {
                using (StreamWriter sw = new StreamWriter("text2.txt", true))
                {
                    await sw.WriteLineAsync(message);
                    await Task.Delay(2000);
                }

            }
            finally
            {
                semaphore.Release();
            }
             return $"written:{message}";


        }
    }
}
