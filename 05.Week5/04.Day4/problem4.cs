
using System;
using System.IO;

using System;
using System.IO;

namespace ConsoleApp4
{
    class Program
    {
        static void Main()
        {

            try
            {
                Console.Write("Enter root directory path: ");
                string rootPath = Console.ReadLine();

                // Validate directory
                if (!Directory.Exists(rootPath))
                {
                    Console.WriteLine("Invalid directory path.");
                    return;
                }

                // Create DirectoryInfo object
                DirectoryInfo rootDir = new DirectoryInfo(rootPath);

                Console.WriteLine("\nSubdirectories and File Counts:\n");

                // Get all subdirectories
                DirectoryInfo[] directories = rootDir.GetDirectories();

                // Loop through each directory
                foreach (DirectoryInfo dir in directories)
                {
                    try
                    {
                        // Get files count
                        FileInfo[] files = dir.GetFiles();

                        Console.WriteLine($"Folder: {dir.Name}");
                        Console.WriteLine($"Number of files: {files.Length}");
                        Console.WriteLine("---------------------------");
                    }
                    catch (UnauthorizedAccessException)
                    {
                        Console.WriteLine($"Folder: {dir.Name}");
                        Console.WriteLine("Access denied.");
                        Console.WriteLine("---------------------------");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error accessing {dir.Name}: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }
}