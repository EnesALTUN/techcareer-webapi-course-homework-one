using Core;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> GetProducts()
        {
            List<Product> products = await _productService.GetAllProductAsync();

            return Ok(new ApiReturn<List<Product>> { Success = true, Code = StatusCodes.Status200OK, Data = products, Message = "All Products", InternalMessage = "Get All Products" });
        }

        [HttpGet("{ProductId}")]
        public async Task<IActionResult> GetProduct(int ProductId)
        {
            Product product = await _productService.GetByProductIdAsync(ProductId);

            return Ok(new ApiReturn<Product> { Success = true, Code = StatusCodes.Status200OK, Data = product, Message = "Product", InternalMessage = "Get Product" });
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
        public async Task<IActionResult> GetProductWithCategoryId(int CategoryId)
        {
            if (CategoryId.Equals(null))
                return null;

            List<Product> getProductsWithCategoryId = await _productService.GetProductWithCriteriaAllAsync(
                    filter => filter.CategoryId.Equals(CategoryId)
                );

            return Ok(new ApiReturn<List<Product>> { Success = true, Code = StatusCodes.Status200OK, Data = getProductsWithCategoryId, Message = "Product With CategoryId", InternalMessage = "Get Product With CategoryId" });
        }
    }
}