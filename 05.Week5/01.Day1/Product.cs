using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace ConsoleApp2
{
    internal class Product
    {
        private String _ProductName;
        private double _Price;
        public Product(string productName, double price)
        {
            _ProductName = productName;
            _Price = price;
            
        }
        public virtual String CalculateDiscount()
        {
            return $" {ProductName}, {Price}"; 
        }

        public String ProductName { get; set; }
        public double Price
        {
            get
            {
                return _Price;
            }
            set
            {
                if(value<=0)
                {
                    Console.WriteLine("price must be greater than zero");
                }
                _Price = value;
            }
        }
        

    }
    internal class Electronics : Product
    {
        public Electronics(string productName, double price):base(productName,price)
        {

        }
        public override String  CalculateDiscount()
        {
            base.CalculateDiscount();
            Price= Price-(Price* 0.05);
            return $"Electronics: {ProductName}, price: {Price}";

        }

    }
    internal class Clothing : Product
    {
        public Clothing(string productName, double price) : base(productName, price)
        {

        }
        public override String CalculateDiscount()
        {
            base.CalculateDiscount();
            Price = Price - (Price * 0.15);
            return $"Clothing: {ProductName}, price: {Price}";
        }

    }
}
