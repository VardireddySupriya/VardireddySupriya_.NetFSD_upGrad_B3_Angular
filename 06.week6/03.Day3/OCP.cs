using System;
using System.Collections.Generic;

namespace ConsoleApp4
{
    public interface IDiscountStrategy
    {
        double CalculateDiscount(double amount);
    }
    public class RegularCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.05; 
        }
    }
    public class PremiumCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.10;
        }
    }
    public class VipCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.20; 
        }
    }
    public class PriceCalculator
    {
        private readonly IDiscountStrategy _discountStrategy;

        public PriceCalculator(IDiscountStrategy discountStrategy)
        {
            _discountStrategy = discountStrategy;
        }

        public double CalculateFinalPrice(double amount)
        {
            double discount = _discountStrategy.CalculateDiscount(amount);
            return amount - discount;
        }
    }

class Program
    {
        static void Main(string[] args)
        {
            double amount = 1000;

           
            IDiscountStrategy discountStrategy = new PremiumCustomerDiscount();

            PriceCalculator calculator = new PriceCalculator(discountStrategy);

            double finalPrice = calculator.CalculateFinalPrice(amount);

            Console.WriteLine("Original Amount: " + amount);
            Console.WriteLine("Final Price after Discount: " + finalPrice);

            Console.ReadLine();
        }
    }


}