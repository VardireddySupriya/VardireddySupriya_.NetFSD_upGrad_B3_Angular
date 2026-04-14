using backend_mini_project1.Models;

namespace backend_mini_project1.Repository
{
    public interface IOrderRepository
    {
        Task<Orders> CreateOrderAsync(Orders order);
        Task<IEnumerable<Orders>> GetAllOrdersAsync();
        Task<Orders> GetOrderByIdAsync(int id);
    }
}
