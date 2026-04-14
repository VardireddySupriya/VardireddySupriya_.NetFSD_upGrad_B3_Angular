using backend_mini_project1.Models;

namespace backend_mini_project1.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDTO>> GetAllProductsAsync();
        Task<ProductResponseDTO> GetProductByIdAsync(int id);
        Task<ProductResponseDTO> AddProductAsync(ProductDTO dto);
        Task<ProductResponseDTO> UpdateProductAsync(int id, ProductDTO dto);
        Task<bool> DeleteProductAsync(int id);

    }
}
