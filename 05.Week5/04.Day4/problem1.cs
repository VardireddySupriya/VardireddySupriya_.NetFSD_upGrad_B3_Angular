using System.IO;
using System.Reflection.Metadata;

namespace ConsoleApp4
{
    class Program
    {
        static void Main()
        {
            String dirname = "logs";
            try
            {
                if (Directory.Exists(dirname) == false)
                {
                    Directory.CreateDirectory(dirname);
                }
                Console.WriteLine("enter message:");
                string message = Console.ReadLine();
                string logFilePath = Path.Combine("logs", "active_log.txt");
                FileStream fs = new FileStream(logFilePath,FileMode.Append, FileAccess.Write);
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(message + "--" + DateTime.Now.ToString());
                }

                Console.WriteLine("Data entered successfully.");
                //StreamWriter sw= new StreamWriter(logFilePath,true);
                //sw.WriteLine("hello");
                //sw.WriteLine("good morning");
                //sw.Close();
                //Console.WriteLine("data entered successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing to file: " + ex.Message);
            }








        }
    }

}
