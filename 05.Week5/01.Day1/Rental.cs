using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    internal class Rental
    {
        private String _Brand;
        private double _RentalRatePerDay;
        public Rental(string brand, double rentalRatePerDay)
        {
            _Brand = brand;
            _RentalRatePerDay = rentalRatePerDay;
        }
        public string Brand
        {
            get { return _Brand; }
            set { _Brand = value; }
        }

        public double RentalRatePerDay
        {
            get { return _RentalRatePerDay; }
            set { _RentalRatePerDay = value; }
        }
        public virtual String CalculateRental(int days)
        {
            return $"brand:{Brand},RenatalRatePerDay{RentalRatePerDay}";
        }
    }
    internal class Car : Rental
    {
        public Car(String brand, double rentalRatePerDay) : base(brand, rentalRatePerDay)
        {
        }
        public override String CalculateRental(int days)
        {
            base.CalculateRental(days);
             double total=RentalRatePerDay*days;
            return $"brand: {Brand},RenatalRatePerDay: {RentalRatePerDay},days: {days},total: {total}";
        }
    }
    internal class Bike:Rental
    {
        public Bike(String Brand, double rentalRatePerDay) : base(Brand, rentalRatePerDay)
        {
        }
        public override String CalculateRental(int days)
        {
            base.CalculateRental(days);
            double total = RentalRatePerDay * days;
            total = total - (total * 0.05);
            return $"brand: {Brand},RenatalRatePerDay: {RentalRatePerDay},days: {days},total: {total}";
        }

    }
}

