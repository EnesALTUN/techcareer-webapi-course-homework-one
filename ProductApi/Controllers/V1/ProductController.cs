using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductService.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductApi.V1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<List<Product>> GetProducts()
        {
            return await _productService.GetAllProductAsync();
        }

        [HttpGet("{ProductId}")]
        public async Task<Product> GetProduct(int ProductId)
        {
            return await _productService.GetByProductIdAsync(ProductId);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            Product addedProduct = await _productService.AddProductAsync(product);

            return CreatedAtAction("GetProduct", "Product", new { ProductId = product.ProductId }, addedProduct);
        }

        [HttpDelete("{ProductId}")]
        public async Task<IActionResult> DeleteProduct(int ProductId)
        {
            await _productService.DeleteProductAsync(ProductId);

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _productService.UpdateProduct(product);

            return Ok();
        }

        [HttpGet("Category/{CategoryId}")]
        public async Task<List<Product>> GetProductWithCategoryId(int CategoryId)
        {
            if (CategoryId.Equals(null))
                return null;

            return await _productService.GetProductWithCriteriaAllAsync(
                    filter => filter.CategoryId.Equals(CategoryId)
                );
        }
    }
}