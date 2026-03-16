namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount b1 = new BankAccount(12345678,2000);
            b1.Deposit(2000);
            Console.WriteLine("after deposit amount is" + b1.GetBalance());
            //b1.WithDraw(5000);
            //Console.WriteLine("after withdraw amount is" + b1.GetBalance());
            b1.WithDraw(2000);
            Console.WriteLine("after withdraw amount is" + b1.GetBalance());

        }

    }
}
