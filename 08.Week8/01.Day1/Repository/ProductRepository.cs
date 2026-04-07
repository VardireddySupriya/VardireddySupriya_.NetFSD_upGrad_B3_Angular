using Dapper;
using Microsoft.Data.SqlClient;
using WebApplication7.Models;

namespace WebApplication7.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connStr;
        public ProductRepository(IConfiguration config)
        {
            _connStr = config.GetConnectionString("DefaultConnection");
        }


        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connStr);
        }

        public IEnumerable<Products> GetAll()
        {
            string sqlQuery = "SELECT * FROM Products";
            var db = GetConnection();
            return db.Query<Products>(sqlQuery);

        }

        public Products GetById(int id)
        {
            string sqlQuery = "SELECT * FROM Products WHERE Id=" + id;
            var db = GetConnection();
            return db.QueryFirstOrDefault<Products>(sqlQuery);
        }

        public void Add(Products product)
        {
            string sqlQuery = @"INSERT INTO Products (Name, Price, Category) VALUES (@Name, @Price, @Category)";

            var db = GetConnection(); 
            db.Execute(sqlQuery, product);
        }
        public void Update(Products product)
        {
            string sqlQuery = @"Update Products set Name=@Name,Price=@price,Category=@Category where id=@id";
            var db = GetConnection();
            db.Execute(sqlQuery, product);

        }
        public void Delete(int id)
        {
            string sqlQuery = "Delete  Products where id=" + id;
            var db = GetConnection();
            db.Execute(sqlQuery, id);

        }
    }
}
