//1.Read array of numbers from the user 
//2.    Send that array to a method :   GetEvenOddCounts()
//3.    int[] GetEvenOddTotals(int[] ar)
//4.Finally display the result in main method

using System;
using System.IO;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount(5000);
            try
            {
                Console.Write("Enter amount to withdraw: ");
                double amount = Convert.ToDouble(Console.ReadLine());

                account.Withdraw(amount);
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine("Custom Exception: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("block");
            }

        }




    }


}



