using backend_mini_project1.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_mini_project1.Repository
{
    public class OrderRepository:IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Orders> CreateOrderAsync(Orders order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<IEnumerable<Orders>> GetAllOrdersAsync()
        {
            return await _context.Orders
                .Include(o => o.Users)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Products)
                .ToListAsync();
        }

        public async Task<Orders> GetOrderByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.OrderId == id);
        }

    }
}
