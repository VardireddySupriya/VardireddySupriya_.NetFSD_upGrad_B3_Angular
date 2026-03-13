//Write a  C# program to process product details using object oriented programming.
 
//•	Class should contain private variables:  productId, productName, unitPrice, qty.
//•	Constructor should allow productId as parameter
//•	 Create properties for all private variables.Property Names :   ProductId, ProductName, UnitPrice, Quantity
//•	ProductId – should be readonly property
//•	ShowDetails()  method to display all the details along with total amount.


using System;
using System.Numerics;

namespace ConsoleApp4
{
    internal class Product
    {
        private int _productId;
        private String _productName;
        private int _unitPrice;
        private int _qty;
        public Product(int productId)
        {
            this._productId = productId;
        }
        public int productId
        {
            get { return this._productId; }
            //set { this._productId = value; }
        }
        public String productName
        {
            get { return this._productName; }
            set { this._productName = value; }
        }
        public int unitPrice
        {
            get { return this._unitPrice; }
            set { this._unitPrice = value; }
        }
        public int qty
        {
            get { return this._qty; }
            set { this._qty = value; }
        }
       public void showDetails()
        {
            int totalPrice = unitPrice * qty;
            Console.WriteLine($"productDetails:");
            Console.WriteLine($"productId:{productId},productName:{productName},unitPrice:{unitPrice},quantity:{qty},totalPrice:{totalPrice}");
        }

        static void Main(string[] args)
        {
            Product p1 = new Product(1);
            p1.productName = "test";
            p1.unitPrice = 500;
            p1.qty = 2;
            Product p2 = new Product(2);
            p2.productName = "test";
            p2.unitPrice = 500;
            p2.qty = 5;
            p1.showDetails();
            p2.showDetails();
            Console.WriteLine();
            Console.ReadLine();



            

            
        }
    }
}
