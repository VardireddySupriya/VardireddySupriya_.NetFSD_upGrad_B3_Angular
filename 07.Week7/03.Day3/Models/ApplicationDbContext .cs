using Microsoft.EntityFrameworkCore;
using System.Data;

namespace WebApplication2.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
 :      base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Movie> Movies { get; set; }
        //public DbSet<Employee> Employees { get; set; }
        //public DbSet<ContactInfo> contactInfo { get; set; }
    }
}
