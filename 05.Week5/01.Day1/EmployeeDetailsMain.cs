namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager m1=new Manager("scott",50000);
            Console.WriteLine(m1.ShowDetails());
            Developer d1 = new Developer("scott", 50000);
            Console.WriteLine(d1.ShowDetails());
            Console.ReadLine();

        }

    }
}


