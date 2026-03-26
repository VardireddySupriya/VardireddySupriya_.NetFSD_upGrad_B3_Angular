using System;
using System.Collections.Generic;

namespace ConsoleApp4
{
    public interface IPrinter
    {
        void Print(string document);
    }
    public interface IScanner
    {
        void Scan(string document);
    }
    public interface IFax
    {
        void Fax(string document);
    }

    public class BasicPrinter : IPrinter
    {
        public void Print(string document)
        {
            Console.WriteLine("Printing document: " + document);
        }
    }
   

    public class AdvancedPrinter : IPrinter, IScanner, IFax
    {
        public void Print(string document)
        {
            Console.WriteLine("Printing document: " + document);
        }

        public void Scan(string document)
        {
            Console.WriteLine("Scanning document: " + document);
        }

        public void Fax(string document)
        {
            Console.WriteLine("Faxing document: " + document);
        }
    }
   

 class Program
    {
        static void Main(string[] args)
        {
            
            IPrinter basicPrinter = new BasicPrinter();
            basicPrinter.Print("Report.pdf");

            Console.WriteLine();

           
            AdvancedPrinter advancedPrinter = new AdvancedPrinter();
            advancedPrinter.Print("Report.pdf");
            advancedPrinter.Scan("Report.pdf");
            advancedPrinter.Fax("Report.pdf");

            Console.ReadLine();
        }
    }
}