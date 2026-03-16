namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car c1 = new Car("toyato", 2000);
            Console.WriteLine(c1.CalculateRental(3));
            Bike b1 = new Bike("honda", 500);
            Console.WriteLine(b1.CalculateRental(3));



        }

    }
}


