using System;

namespace ConsoleApp5
{
    internal class EmpDetailsHR
    {
        private string _FullName;
        private int _Age;
        private int _EmpId;

        public string FullName
        {
            get { return _FullName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                _FullName = value.Trim();
            }
        }

        public int Age
        {
            get { return _Age; }
            set
            {
                if (value >= 18 && value <= 80)
                {
                    _Age = value;
                }
                else
                {
                    throw new ArgumentException("Invalid Age");
                }
            }
        }

        public decimal Salary { get; private set; }

        public int EmpId
        {
            get { return _EmpId; }
        }

        public EmpDetailsHR(string FullName, decimal Salary, int Age)
        {
            if (string.IsNullOrWhiteSpace(FullName))
            {
                throw new ArgumentException("Name cannot be empty");
            }

            if (Age < 18 || Age > 80)
            {
                throw new ArgumentException("Invalid age for work");
            }

            if (Salary < 1000)
            {
                throw new ArgumentException("Invalid salary number");
            }

            _FullName = FullName.Trim();
            _Age = Age;
            this.Salary = Salary;
        }

        public void GiveRaise(decimal percentage)
        {
            if (percentage <= 0 || percentage > 30)
            {
                Console.WriteLine("Invalid percentage to increase salary");
                return;
            }

            decimal totalSalary = Salary + (Salary * percentage / 100);

            Console.WriteLine($"Before salary is {Salary}");

            Salary = totalSalary;

            Console.WriteLine($"Salary increased by {percentage}%");
            Console.WriteLine($"New salary is {Salary}");
        }

        public bool DeductPenalty(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Penalty must be greater than zero");
                return false;
            }

            if (Salary - amount < 1000)
            {
                Console.WriteLine("Salary must remain ≥ 1000");
                return false;
            }

            Salary -= amount;

            Console.WriteLine($"Penalty deducted. New salary: {Salary}");
            Console.WriteLine($"empName: {FullName}, salary: {Salary}, empid: {EmpId}");

            return true;
        }
    }
}
