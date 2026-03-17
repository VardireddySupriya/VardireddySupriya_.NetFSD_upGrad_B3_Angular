using System;
using System.Collections.Generic;
using System.Text;


namespace ConsoleApp3
{
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message)
        {
        }
    }
    internal class BankAccount
    {
        private double _Balance;
        public double Balance
        {
            get
            {
                return _Balance;
            }
            set
            {
                _Balance = value;
            }
        }
        public BankAccount(double bal)
        {
            _Balance = bal;
        }
        public void Withdraw(double amount)
        {
            if(_Balance<amount)
            {
                throw new InsufficientBalanceException("insufficient funds");
            }
            _Balance -= amount;
            Console.WriteLine("Withdrawal successful!");
            Console.WriteLine("Remaining Balance: " + _Balance);

        }


    }
}
