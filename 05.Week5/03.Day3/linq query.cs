using LinqCodeTemplate;
using System;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    internal class Product
    {
        public int ProCode { get; set; }

        public string ProName { get; set; }

        public string ProCategory { get; set; }

        public double ProMrp { get; set; }

        public List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product{ProCode=1001,ProName="Colgate-100gm",ProCategory="FMCG",ProMrp=55 },
                 new Product{ProCode=1002,ProName="Colgate-50gm",ProCategory="FMCG",ProMrp=30 },
                 new Product{ProCode=1009,ProName="DaburRed-100gm",ProCategory="FMCG",ProMrp=50 },
                 new Product{ProCode=1006,ProName="DaburRed-50gm",ProCategory="FMCG",ProMrp=28 },
                 new Product{ProCode=1008,ProName="Himalaya Neem Face Wash",ProCategory="FMCG",ProMrp=70 },
                 new Product{ProCode=1007,ProName="Niviea Face Wash",ProCategory="FMCG",ProMrp=120 },
                 new Product{ProCode=1010,ProName="Daawat-Basmati",ProCategory="Grain",ProMrp=130 },
                  new Product{ProCode=1011,ProName="Delhi Gate-Basmati",ProCategory="Grain",ProMrp=120 },
                  new Product{ProCode=1014,ProName="Saffola-Oil",ProCategory="Edible-Oil",ProMrp=160 },
                   new Product{ProCode=1016,ProName="Fortune-Oil",ProCategory="Edible-Oil",ProMrp=150 },
                   new Product{ProCode=1018,ProName="Nescafe",ProCategory="FMCG",ProMrp=70 },
                   new Product{ProCode=1019,ProName="Bru",ProCategory="FMCG",ProMrp=90},
                    new Product{ProCode=1015,ProName="Parachut",ProCategory="Edible-Oil",ProMrp=60}
            };

        }
    }
}

class Program
{
   
    static void Main(string[] args)
    {
        Product product = new Product();
        var products = product.GetProducts();
        //var result = products.Where(p => p.ProCategory == "FMCG").ToList();
        var result = from p in products
                     where p.ProCategory == "FMCG"
                     select p;
        foreach (var item in result)
        {
            Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
        }

        Console.WriteLine("\n----------------");


        //var result1=products.Where(g=>g.ProCategory=="Grain").ToList();
        var result1 = from p in products
                      where p.ProCategory == "Grain"
                      select p;
        
        foreach (var item in result1)
        {
            Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
        }
        Console.WriteLine("\n-----ascending by procode-----------");

        //----OrderedDictionary by 
        //var result2=products.OrderBy(product=>product.ProCode);
        var result2 = from p in products
                      orderby p.ProCode
                      select p;
        foreach (var item in result2)
        {
            Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
        }
        Console.WriteLine("\n-------ascending by category---------");
        //var result3 = products.OrderBy(product => product.ProCategory);
        var result3 = from p in products
                      orderby p.ProCategory
                      select p;
        foreach (var item in result3)
        {
            Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}\t{item.ProCategory}");
        }
        Console.WriteLine("\n------ascending by mrp----------");
        //var result4 = products.OrderBy(m => m.ProMrp);
        var result4 = from p in products
                      orderby p.ProMrp
                      select p;
        foreach (var item in result4)
        {
            Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}\t{item.ProCategory}");
        }
        Console.WriteLine("\n------descending by mrp ----------");
        //var result5 = products.OrderByDescending(m => m.ProMrp);
        var result5 = from p in products
                      orderby p.ProMrp descending
                      select p;
        foreach (var item in result5)
        {
            Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}\t{item.ProCategory}");
        }
        Console.WriteLine("\n------group by category----------");
        //var result6 = products.GroupBy(p => p.ProCategory);
        var result6 = from p in products
                      group p by p.ProCategory into g
                      select new
                      {
                          Category = g.Key,
                          Products = g.ToList()
                      };

        foreach (var group in result6)
        {
            Console.WriteLine($"Category: {group.Category}"); // use Category, not Key

            foreach (var item in group.Products)  // iterate over Products
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            }

            Console.WriteLine(); // Blank line for readability
        }
        Console.WriteLine("\n------ group by mrp----------");
        var result7 = products.GroupBy(p => p.ProMrp);

        foreach (var group in result7)
        {
            Console.WriteLine($"Category: {group.Key}"); // Group Key is the category

            foreach (var item in group)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            }

            Console.WriteLine(); // Blank line for readability
        }
        Console.WriteLine("\n------highest price in FMCG ----------");
        var result8 = products
                    .Where(p => p.ProCategory == "FMCG")   
                    .OrderByDescending(p => p.ProMrp)    
                    .FirstOrDefault();                  

        if (result8 != null)
        {
            Console.WriteLine($"Highest FMCG Product: {result8.ProCode}\t{result8.ProName}\t{result8.ProMrp}");
        }
        Console.WriteLine("\n---products count-------------");
        int totalProducts = products.Count();
        Console.WriteLine($"Total Products: {totalProducts}");
        Console.WriteLine("\n--total products in fmcg--------------");
        int totalFMCG = products.Count(p => p.ProCategory == "FMCG");
        Console.WriteLine($"Total FMCG Products: {totalFMCG}");
        Console.WriteLine("\n-----maximum-----------");
        double maxPrice = products.Max(p => p.ProMrp);
        Console.WriteLine($"Maximum Price: {maxPrice}");
        Console.WriteLine("\n-----minimum-----------");
        double minPrice = products.Min(p => p.ProMrp);
        Console.WriteLine($"Minimum Price: {minPrice}");
        Console.WriteLine("\n-----all below 30 or not-----------");
        bool all= products.All(p => p.ProMrp < 30);
        Console.WriteLine($"Are all products below Rs.30? {all}");
        Console.WriteLine("\n-----any product below 30 or not-----------");
        bool any = products.Any(p => p.ProMrp < 30);
        Console.WriteLine($"Are all products below Rs.30? {any}");








    }
}