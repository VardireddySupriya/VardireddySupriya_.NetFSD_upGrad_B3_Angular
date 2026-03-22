using System.IO;
using System.Reflection;
using System.Reflection.Metadata;

namespace ConsoleApp4
{
    class Program
    {
        static void Main()
        {
            //string filename = @"C:\Users\ADMIN\Desktop\c# files\file1.txt";
            try
            {
                
                Console.WriteLine("------------------------------------");
                string path = @"C:\Users\ADMIN\Desktop\c# files\basics";
                if (!Directory.Exists(path))
                {
                    Console.WriteLine("Invalid directory path.");
                    return;
                }

                DirectoryInfo directory = new DirectoryInfo(path);
                FileInfo[] files = directory.GetFiles();

                Console.WriteLine("\nFile Details:\n");


                foreach (FileInfo file in files)
                {
                    Console.WriteLine("File Name: " + file.Name);
                    Console.WriteLine("Size (bytes): " + file.Length);
                    Console.WriteLine("Created On: " + file.CreationTime);
                    Console.WriteLine("---------------------------");
                }

                
                Console.WriteLine("Total number of files: " + files.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine("some error occur");
            }
            Console.ReadLine();








        }
    }

}
