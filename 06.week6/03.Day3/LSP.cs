using System;
using System.Collections.Generic;

namespace ConsoleApp4
{
    public abstract class Shape
    {
        public abstract double CalculateArea();
    }
    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override double CalculateArea()
        {
            return Width * Height;
        }
    }


    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

public class AreaCalculator
    {
        public void PrintArea(Shape shape)
        {
            Console.WriteLine("Area: " + shape.CalculateArea());
        }
    }
class Program
    {
        static void Main(string[] args)
        {
            AreaCalculator calculator = new AreaCalculator();

            
            Shape rectangle = new Rectangle(5, 10);
            calculator.PrintArea(rectangle);

           
            Shape circle = new Circle(7);
            calculator.PrintArea(circle);

            Console.ReadLine();
        }
    }
}