
using backend_mini_project1.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_mini_project1.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //  GET ALL
        public async Task<IEnumerable<Products>> GetAllAsync()
        {
            return await _context.Products.ToListAsync(); // removed Include
        }

        // ✅ GET BY ID
        public async Task<Products> GetByIdAsync(int id)
        {
            return await _context.Products
                .FirstOrDefaultAsync(p => p.ProductId == id);
        }

        //  ADD
        public async Task<Products> AddAsync(Products product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        // UPDATE
        public async Task<Products> UpdateAsync(int id, Products product)
        {
            var existing = await _context.Products
                .FirstOrDefaultAsync(p => p.ProductId == id);

            if (existing == null)
                return null;

            //  DO NOT update ProductId
            existing.Name = product.Name;
            existing.Description = product.Description;
            existing.Price = product.Price;
            existing.ImageUrl = product.ImageUrl;
            existing.Stock = product.Stock;

            await _context.SaveChangesAsync();

            return existing;
        }

        //  DELETE
        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.ProductId == id);

            if (product == null)
                return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
