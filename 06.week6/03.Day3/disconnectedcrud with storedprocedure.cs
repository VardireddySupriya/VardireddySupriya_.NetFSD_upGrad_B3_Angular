using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Linq;

namespace ConsoleApp4
{
    class Program
    {
        static string connStr;

        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            connStr = config.GetConnectionString("DefaultConnection");

            while (true)
            {
                Console.WriteLine("\n1. Get All Products");
                Console.WriteLine("2. Insert Product");
                Console.WriteLine("3. Update Product");
                Console.WriteLine("4. Delete Product");
                Console.WriteLine("5. Get Product By Id");
                Console.WriteLine("6. Exit");

                Console.Write("Enter choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1: GetAllProducts(); break;
                    case 2: InsertProduct(); break;
                    case 3: UpdateProduct(); break;
                    case 4: DeleteProduct(); break;
                    case 5: GetProductById(); break;
                    case 6: return;
                }
            }
        }

        //Get all products
        static void GetAllProducts()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                //disconnected adapter bridge between the db and application
                SqlDataAdapter adapter = new SqlDataAdapter("GetAllProducts", conn);
                //commandtype
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                //create in memory table to store
                DataTable table = new DataTable();
                //to fetch and store the data in a table
                adapter.Fill(table);

                foreach (DataRow row in table.Rows)
                {
                    Console.WriteLine($"{row["productId"]}, {row["productName"]}, {row["productCategory"]}, {row["price"]}");
                }
            }
        }

        // insert
        static void InsertProduct()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("GetAllProducts", conn);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

               
                adapter.InsertCommand = new SqlCommand("InsertProduct", conn);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;

                adapter.InsertCommand.Parameters.Add("@productName", SqlDbType.VarChar, 50, "productName");
                adapter.InsertCommand.Parameters.Add("@productCategory", SqlDbType.VarChar, 50, "productCategory");
                adapter.InsertCommand.Parameters.Add("@price", SqlDbType.Decimal, 0, "price");

                DataTable table = new DataTable();
                adapter.Fill(table);

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Category: ");
                string category = Console.ReadLine();

                Console.Write("Enter Price: ");
                decimal price = Convert.ToDecimal(Console.ReadLine());

                DataRow row = table.NewRow();
                row["productName"] = name;
                row["productCategory"] = category;
                row["price"] = price;

                table.Rows.Add(row);

                int rows = adapter.Update(table);
                Console.WriteLine("Inserted: " + rows);
            }
        }

        // 🔹 UPDATE
        static void UpdateProduct()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("GetAllProducts", conn);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                adapter.UpdateCommand = new SqlCommand("UpdateProduct", conn);
                adapter.UpdateCommand.CommandType = CommandType.StoredProcedure;

                adapter.UpdateCommand.Parameters.Add("@productId", SqlDbType.Int, 0, "productId");
                adapter.UpdateCommand.Parameters.Add("@productName", SqlDbType.VarChar, 50, "productName");
                adapter.UpdateCommand.Parameters.Add("@productCategory", SqlDbType.VarChar, 50, "productCategory");
                adapter.UpdateCommand.Parameters.Add("@price", SqlDbType.Decimal, 0, "price");

                DataTable table = new DataTable();
                adapter.Fill(table);

                Console.Write("Enter Id: ");
                int id = Convert.ToInt32(Console.ReadLine());

                DataRow row = table.Select($"productId = {id}").FirstOrDefault();

                if (row != null)
                {
                    Console.Write("Enter Name: ");
                    row["productName"] = Console.ReadLine();

                    Console.Write("Enter Category: ");
                    row["productCategory"] = Console.ReadLine();

                    Console.Write("Enter Price: ");
                    row["price"] = Convert.ToDecimal(Console.ReadLine());

                    int rows = adapter.Update(table);
                    Console.WriteLine("Updated: " + rows);
                }
                else
                {
                    Console.WriteLine("Product not found");
                }
            }
        }

        // 🔹 DELETE
        static void DeleteProduct()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("GetAllProducts", conn);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                adapter.DeleteCommand = new SqlCommand("DeleteProduct", conn);
                adapter.DeleteCommand.CommandType = CommandType.StoredProcedure;

                adapter.DeleteCommand.Parameters.Add("@productId", SqlDbType.Int, 0, "productId");

                DataTable table = new DataTable();
                adapter.Fill(table);

                Console.Write("Enter Id: ");
                int id = Convert.ToInt32(Console.ReadLine());

                DataRow row = table.Select($"productId = {id}").FirstOrDefault();

                if (row != null)
                {
                    row.Delete();

                    int rows = adapter.Update(table);
                    Console.WriteLine("Deleted: " + rows);
                }
                else
                {
                    Console.WriteLine("Product not found");
                }
            }
        }

        // 🔹 GET BY ID
        static void GetProductById()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("GetAllProducts", conn);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable table = new DataTable();
                adapter.Fill(table);

                Console.Write("Enter Id: ");
                int id = Convert.ToInt32(Console.ReadLine());

                DataRow[] rows = table.Select("productId = " + id);

                if (rows.Length > 0)
                {
                    foreach (DataRow row in rows)
                    {
                        Console.WriteLine($"{row["productId"]}, {row["productName"]}, {row["productCategory"]}, {row["price"]}");
                    }
                }
                else
                {
                    Console.WriteLine("Product not found");
                }
            }
        }
    }
}