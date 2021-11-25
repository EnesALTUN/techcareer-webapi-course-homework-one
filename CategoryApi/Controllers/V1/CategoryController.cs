using CategoryService.Infrastructure;
using Entities;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<List<Category>> GetCategories()
        {
            return await _categoryService.GetAllCategoryAsync();
        }

        [HttpGet("{CategoryId}")]
        public async Task<Category> GetCategory(int CategoryId)
        {
            return await _categoryService.GetByCategoryIdAsync(CategoryId);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(Category category)
        {
            Category addedCategory = await _categoryService.AddCategoryAsync(category);

            return CreatedAtAction("GetCategory", "Category", new { CategoryId = category.CategoryId }, addedCategory);
        }
    }
}