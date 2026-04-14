using backend_mini_project1.Models;

namespace backend_mini_project1.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Products>> GetAllAsync();
        Task<Products> GetByIdAsync(int id);
        Task<Products> AddAsync(Products product);
        Task<Products> UpdateAsync(int id, Products product);
        Task<bool> DeleteAsync(int id);
    }
}
