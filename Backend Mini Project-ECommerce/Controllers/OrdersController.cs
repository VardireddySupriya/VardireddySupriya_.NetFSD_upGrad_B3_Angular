using backend_mini_project1.Models;
using backend_mini_project1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace backend_mini_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderRequestDTO request)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            request.UserId = userId;

            var result = await _orderService.ProcessOrderAsync(request);

            if (!result.Success)
                return BadRequest(new { message = result.Message });

            return CreatedAtAction(nameof(GetOrderById),
                new { id = result.OrderId },
                result);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllOrders()
        {
            var roleClaim = User.FindFirst(ClaimTypes.Role);
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
                return Unauthorized(new { message = "Invalid token - UserId missing" });

            int userId = int.Parse(userIdClaim.Value);

            var orders = await _orderService.GetAllOrdersAsync();

            if (orders == null || !orders.Any())
                return NoContent();

            // USER → only own orders
            if (roleClaim != null && roleClaim.Value == "User")
            {
                orders = orders.Where(o => o.UserId == userId).ToList();
            }

            return Ok(orders);
        }

        // GET ORDER BY ID 
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetOrderById(int id)
        {
            if (id <= 0)
                return BadRequest(new { message = "Invalid Order Id" });

            var order = await _orderService.GetOrderByIdAsync(id);

            if (order == null)
                return NotFound(new { message = "Order not found" });

            var role = User.FindFirst(ClaimTypes.Role)?.Value;
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            if (role == "User" && order.UserId != userId)
                return Forbid();

            return Ok(order);
        }
    }
}

