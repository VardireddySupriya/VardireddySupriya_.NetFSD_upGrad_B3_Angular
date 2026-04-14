
using backend_mini_project1.Models;
using backend_mini_project1.Repository;
using backend_mini_project1.Services;
using Microsoft.EntityFrameworkCore;

namespace backend_mini_project.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IProductRepository _productRepo;
        private readonly ApplicationDbContext _context;

        public OrderService(
            IOrderRepository orderRepo,
            IProductRepository productRepo,
            ApplicationDbContext context)
        {
            _orderRepo = orderRepo;
            _productRepo = productRepo;
            _context = context;
        }

      
        public async Task<OrderResultDTO> ProcessOrderAsync(OrderRequestDTO request)
        {
            var orderItems = new List<OrderItems>();

            // 1️ Validate request
            if (request.Items == null || !request.Items.Any())
            {
                return new OrderResultDTO
                {
                    Success = false,
                    Message = "Order items required"
                };
            }

            // 2 FIRST PASS → VALIDATION ONLY (NO STOCK REDUCTION)
            foreach (var item in request.Items)
            {
                var product = await _productRepo.GetByIdAsync(item.ProductId);

                if (product == null)
                {
                    return new OrderResultDTO
                    {
                        Success = false,
                        Message = $"Product {item.ProductId} not found"
                    };
                }

                if (item.Quantity <= 0)
                {
                    return new OrderResultDTO
                    {
                        Success = false,
                        Message = "Quantity must be greater than zero"
                    };
                }

                if (product.Stock < item.Quantity)
                {
                    return new OrderResultDTO
                    {
                        Success = false,
                        Message = $"X Stock not available for {product.Name}. Available stock: {product.Stock}"
                    };
                }
            }

            // 3️ SECOND PASS → CREATE ORDER + REDUCE STOCK
            foreach (var item in request.Items)
            {
                var product = await _productRepo.GetByIdAsync(item.ProductId);

                orderItems.Add(new OrderItems
                {
                    ProductId = product.ProductId,
                    Quantity = item.Quantity,
                    Price = product.Price
                });

                product.Stock -= item.Quantity;
                _context.Products.Update(product);
            }

            // 4️ TOTAL CALCULATION
            var total = orderItems.Sum(x => x.Price * x.Quantity);

            // 5️ USER
            var user = await _context.Users.FindAsync(request.UserId);

            // 6️ CREATE ORDER
            var order = new Orders
            {
                UserId = request.UserId,
                Users = user,
                OrderDate = DateTime.UtcNow,
                TotalAmount = total,
                OrderItems = orderItems
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return new OrderResultDTO
            {
                Success = true,
                Message = "Order created successfully",
                OrderId = order.OrderId
            };
        }

        // GET ALL ORDERS
        public async Task<List<OrderResponseDTO>> GetAllOrdersAsync()
        {
            return await _context.Orders
                .Include(o => o.Users)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Products)
                .Select(o => new OrderResponseDTO
                {
                    OrderId = o.OrderId,
                    UserId = o.UserId,
                    UserName = o.Users != null ? o.Users.Name : "Unknown",
                    OrderDate = o.OrderDate,
                    TotalAmount = o.TotalAmount,

                    Items = o.OrderItems.Select(oi => new OrderItemResponseDTO
                    {
                        ProductId = oi.ProductId,
                        ProductName = oi.Products.Name,
                        Quantity = oi.Quantity,
                        Price = oi.Price
                    }).ToList()
                })
                .ToListAsync();
        }

        // GET ORDER BY ID
        public async Task<OrderResponseDTO?> GetOrderByIdAsync(int id)
        {
            var order = await _context.Orders
                .Include(o => o.Users)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Products)
                .FirstOrDefaultAsync(o => o.OrderId == id);

            if (order == null)
                return null;

            return new OrderResponseDTO
            {
                OrderId = order.OrderId,
                UserId = order.UserId,
                UserName = order.Users != null ? order.Users.Name : "Unknown",
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,

                Items = order.OrderItems.Select(oi => new OrderItemResponseDTO
                {
                    ProductId = oi.ProductId,
                    ProductName = oi.Products.Name,
                    Quantity = oi.Quantity,
                    Price = oi.Price
                }).ToList()
            };
        }
    }
}
