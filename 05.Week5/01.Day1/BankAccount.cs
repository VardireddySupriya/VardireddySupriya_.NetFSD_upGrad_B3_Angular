using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    internal class BankAccount
    {
        private long _AccountNumber;
        private double _Balance;
        public BankAccount(long accountNumber, double balance)
        {
            this._AccountNumber = accountNumber;
            this._Balance = balance;
        }
        public long AccountNumber
        {
            get;
        }
        public double Balance
        {
            get; set;
        }
        public double WithDraw(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("amount must be positive");
            }
            else if (amount > _Balance)
            {
               throw new ArgumentException("insufficient funds");
            }
            else
            {
                _Balance -= amount;
                
            }
            return _Balance;


        }
        public double Deposit(double amount)
        {
            _Balance += amount;
            return _Balance;
        }
        public double GetBalance()
        {
            return _Balance;
        }



    }
}

