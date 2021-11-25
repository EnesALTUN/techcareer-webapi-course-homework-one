using CategoryService.Infrastructure;
using Core;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CategoryApi.V1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            List<Category> categories = await _categoryService.GetAllCategoryAsync();

            return Ok(new ApiReturn<List<Category>>{ Success = true, Code = StatusCodes.Status200OK, Data = categories, Message = "All Categories", InternalMessage = "Get All Categories" });
        }

        [HttpGet("{CategoryId}")]
        public async Task<IActionResult> GetCategory(int CategoryId)
        {
            Category category = await _categoryService.GetByCategoryIdAsync(CategoryId);

            return Ok(new ApiReturn<Category> { Success = true, Code = StatusCodes.Status200OK, Data = category, Message = "Category", InternalMessage = "Get Category" });
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(Category category)
        {
            Category addedCategory = await _categoryService.AddCategoryAsync(category);

            return CreatedAtAction("GetCategory", "Category", new { CategoryId = category.CategoryId }, addedCategory);
        }
    }
}