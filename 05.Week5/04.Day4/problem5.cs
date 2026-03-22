
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
               
                DriveInfo[] drives = DriveInfo.GetDrives();

                foreach (DriveInfo d in drives)
                {
                    
                    if (d.IsReady)
                    {
                        Console.WriteLine("Drive Name: " + d.Name);
                        Console.WriteLine("Drive Type: " + d.DriveType);
                        Console.WriteLine("Total Size: " + d.TotalSize);
                        Console.WriteLine("Available Free Space: " + d.AvailableFreeSpace);

                        double freePercent = (double)d.AvailableFreeSpace / d.TotalSize * 100;

                        Console.WriteLine("Free Space (%): " + freePercent);

                        
                        if (freePercent < 15)
                        {
                            Console.WriteLine(" Low Disk Storage!");
                        }

                        Console.WriteLine("-----------------------------------");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();
        }
    }
}