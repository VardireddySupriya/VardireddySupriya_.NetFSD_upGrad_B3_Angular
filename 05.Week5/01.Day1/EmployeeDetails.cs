using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    internal class EmployeeDetails
    {
        private String _Name;
        private double _BaseSalary;
        public String Name {  get; set; }
        public double BaseSalary { get; set; }
        public EmployeeDetails(string Name, double BaseSalary)
        {
            this.Name = Name;
            this.BaseSalary = BaseSalary;
        }

        public virtual String ShowDetails()
        {
            return $" {Name}, {BaseSalary}"; ;
        }

    }
    internal class Manager:EmployeeDetails
    {
        public Manager(string Name, double BaseSalary) : base(Name, BaseSalary)
        {
        }

        public override String ShowDetails()
        {
            base.ShowDetails();
            double salary = BaseSalary+BaseSalary * 0.2;
            return $"increment of manager:{salary}";
        }

    }
    internal class Developer : EmployeeDetails
    {
        public Developer(string Name, double BaseSalary) : base(Name, BaseSalary)
        {
        }

        public override String ShowDetails()
        {
            base.ShowDetails();
            double salary = BaseSalary + BaseSalary * 0.1;
            return $"increment of manager:{salary}";
        }

    }
}
