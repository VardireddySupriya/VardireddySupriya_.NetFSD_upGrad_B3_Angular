using backend_mini_project1.Models;

namespace backend_mini_project1.Services
{
    public interface IOrderService
    {
        Task<OrderResultDTO> ProcessOrderAsync(OrderRequestDTO request);

        Task<List<OrderResponseDTO>> GetAllOrdersAsync();

        Task<OrderResponseDTO?> GetOrderByIdAsync(int id);
    }
}
