using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ConsoleApp4
{
    class Program
    {
        static string connStr;

        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            connStr = config.GetConnectionString("DefaultConnection");

            while (true)
            {
                Console.WriteLine("\n1. Get All Products");
                Console.WriteLine("2. Insert Product");
                Console.WriteLine("3. Update Product");
                Console.WriteLine("4. Delete Product");
                Console.WriteLine("5.get Product by id");
                Console.WriteLine("6. Exit");

                Console.Write("Enter choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1: GetAllProducts(); break;
                    case 2: InsertProduct(); break;
                    case 3: UpdateProduct(); break;
                    case 4: DeleteProduct(); break;
                    case 5: GetProductById();break;
                    case 6: return;
                        }
            }
        }

      
        static void GetAllProducts()
        {
            SqlConnection conn = new SqlConnection(connStr);
            string cmdtext = "GetAllProducts";

            using (SqlCommand cmd = new SqlCommand(cmdtext, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"{reader["productId"]}, {reader["productName"]}, {reader["productCategory"]}, {reader["price"]}");
                }

                conn.Close();
            }
        }

       
        static void InsertProduct()
        {
            SqlConnection conn = new SqlConnection(connStr);
            string cmdtext = "insertValues";

            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Category: ");
            string category = Console.ReadLine();

            Console.Write("Enter Price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@productName";
            p1.SqlDbType = SqlDbType.VarChar;
            p1.Value = name;

            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@productCategory";
            p2.SqlDbType = SqlDbType.VarChar;
            p2.Value = category;

            SqlParameter p3 = new SqlParameter();
            p3.ParameterName = "@price";
            p3.SqlDbType = SqlDbType.Decimal;
            p3.Precision = 10;
            p3.Scale = 2;
            p3.Value = price;

            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);

            conn.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("Inserted successfully");
            conn.Close();
        }

      
        static void UpdateProduct()
        {
            SqlConnection conn = new SqlConnection(connStr);
            string cmdtext = "UpdateProduct";

            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            Console.Write("Enter Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Category: ");
            string category = Console.ReadLine();

            Console.Write("Enter Price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@productId";
            p1.SqlDbType = SqlDbType.Int;
            p1.Value = id;

            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@productName";
            p2.SqlDbType = SqlDbType.VarChar;
            p2.Value = name;

            SqlParameter p3 = new SqlParameter();
            p3.ParameterName = "@productCategory";
            p3.SqlDbType = SqlDbType.VarChar;
            p3.Value = category;

            SqlParameter p4 = new SqlParameter();
            p4.ParameterName = "@price";
            p4.SqlDbType = SqlDbType.Decimal;
            p4.Precision = 10;
            p4.Scale = 2;
            p4.Value = price;

            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);

            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine("Updated successfully: " + rows);
            conn.Close();
        }

     
        static void DeleteProduct()
        {
            SqlConnection conn = new SqlConnection(connStr);
            string cmdtext = "DeleteProduct";

            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            Console.Write("Enter Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@productId";
            p1.SqlDbType = SqlDbType.Int;
            p1.Value = id;

            cmd.Parameters.Add(p1);

            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine("Deleted successfully: " + rows);
            conn.Close();
        }
        static void GetProductById()
        {
            SqlConnection conn = new SqlConnection(connStr);
            string cmdtext = "GetProductById";

            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            Console.Write("Enter Product ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@productId";
            p1.SqlDbType = SqlDbType.Int;
            p1.Value = id;

            cmd.Parameters.Add(p1);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["productId"]}, {reader["productName"]}, {reader["productCategory"]}, {reader["price"]}");
                }
            }
            else
            {
                Console.WriteLine("Product not found");
            }

            conn.Close();
        }
    }
}