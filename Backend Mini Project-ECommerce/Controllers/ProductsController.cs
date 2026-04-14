
using backend_mini_project1.Models;
using backend_mini_project1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend_mini_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        //  USER + ADMIN (VIEW ALL)
        [Authorize(Roles = "User,Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var products = await _service.GetAllProductsAsync();
            return Ok(products);
        }

        //  USER + ADMIN (GET BY ID)
        [Authorize(Roles = "User,Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByIdAsync(int id)
        {
            try
            {
                var product = await _service.GetProductByIdAsync(id);
                return Ok(product);
            }
            catch (ApplicationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        //  ADMIN ONLY (CREATE)
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddProductAsync([FromBody]ProductDTO dto)
        {
            var product = await _service.AddProductAsync(dto);

            return Ok(new
            {
                message = "Product added successfully",
                data = product
            });
        }

        //  ADMIN ONLY (UPDATE)
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductAsync([FromBody] ProductDTO dto,[FromRoute]int id)
        {
            try
            {
                var product = await _service.UpdateProductAsync(id, dto);

                return Ok(new
                {
                    message = "Product updated successfully",
                    data = product
                });
            }
            catch (ApplicationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        //  ADMIN ONLY (DELETE)
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            try
            {
                await _service.DeleteProductAsync(id);

                return Ok(new
                {
                    message = "Product deleted successfully"
                });
            }
            catch (ApplicationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
