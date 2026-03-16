namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Electronics e1 = new Electronics("induction stove", 20000);
            Console.WriteLine(e1.CalculateDiscount());
            Clothing c1 = new Clothing("shirt", 2000);
            Console.WriteLine(c1.CalculateDiscount());
            Console.ReadLine();
        }

    }
}


