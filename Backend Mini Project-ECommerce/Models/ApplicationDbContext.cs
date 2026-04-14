using Microsoft.EntityFrameworkCore;

namespace backend_mini_project1.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {

        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Orders>()
             .HasOne(o => o.Users)              // each Order has one User
             .WithMany(u => u.Orders)          // one User has many Orders
             .HasForeignKey(o => o.UserId);    // FK in Orders table


            // 🔹 One Order → Many OrderItems
            modelBuilder.Entity<OrderItems>()
                .HasOne(oi => oi.Orders)           // each OrderItem belongs to one Order
                .WithMany(o => o.OrderItems)      // one Order has many OrderItems
                .HasForeignKey(oi => oi.OrderId);  // FK in OrderItems table
                

            // 🔹 One Product → Many OrderItems
            modelBuilder.Entity<OrderItems>()
                .HasOne(oi => oi.Products)         // each OrderItem has one Product
                .WithMany(p => p.OrderItems)      // one Product has many OrderItems
                .HasForeignKey(oi => oi.ProductId);// FK in OrderItems table
                                                   
        }

    }

}

