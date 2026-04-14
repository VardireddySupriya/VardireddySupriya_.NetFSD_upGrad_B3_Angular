
using backend_mini_project1.Models;
using backend_mini_project1.Repository;
using System.Linq;

namespace backend_mini_project1.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        //  GET ALL (User + Admin)
        public async Task<IEnumerable<ProductResponseDTO>> GetAllProductsAsync()
        {
            var products = await _repo.GetAllAsync();

            return products.Select(p => new ProductResponseDTO
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Stock = p.Stock,
                ImageUrl = p.ImageUrl
            });
        }

        //  GET BY ID (User + Admin)
        public async Task<ProductResponseDTO> GetProductByIdAsync(int id)
        {
            var product = await _repo.GetByIdAsync(id);

            if (product == null)
                throw new ApplicationException("Product not found");

            return new ProductResponseDTO
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                ImageUrl = product.ImageUrl
            };
        }

        //  ADD PRODUCT (Admin)
        public async Task<ProductResponseDTO> AddProductAsync(ProductDTO dto)
        {
            var product = new Products
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Stock = dto.Stock,
                ImageUrl = dto.ImageUrl
            };

            var createdProduct = await _repo.AddAsync(product);

            return new ProductResponseDTO
            {
                ProductId = createdProduct.ProductId,
                Name = createdProduct.Name,
                Description = createdProduct.Description,
                Price = createdProduct.Price,
                Stock = createdProduct.Stock,
                ImageUrl = createdProduct.ImageUrl
            };
        }

        //  UPDATE PRODUCT (Admin)
        public async Task<ProductResponseDTO> UpdateProductAsync(int id, ProductDTO dto)
        {
            var product = await _repo.GetByIdAsync(id);

            if (product == null)
                throw new ApplicationException("Product not found");

            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Price = dto.Price;
            product.Stock = dto.Stock;
            product.ImageUrl = dto.ImageUrl;

            var updated = await _repo.UpdateAsync(id, product);

            //  FIXED (null safety)
            if (updated == null)
                throw new ApplicationException("Update failed");

            return new ProductResponseDTO
            {
                ProductId = updated.ProductId,
                Name = updated.Name,
                Description = updated.Description,
                Price = updated.Price,
                Stock = updated.Stock,
                ImageUrl = updated.ImageUrl
            };
        }

        // DELETE PRODUCT (Admin)
        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _repo.GetByIdAsync(id);

            if (product == null)
                throw new ApplicationException("Product not found");

            var deleted = await _repo.DeleteAsync(id);

            //  FIXED (check result)
            if (!deleted)
                throw new ApplicationException("Delete failed");

            return true;
        }
    }
}