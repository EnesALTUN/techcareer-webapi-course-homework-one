using Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CategoryService.Infrastructure
{
    public interface ICategoryService
    {
        List<Category> GetAllCategory();
        Task<List<Category>> GetAllCategoryAsync();
        Category GetByCategoryId(object id);
        Task<Category> GetByCategoryIdAsync(object id);
        Category GetCategoryWithCriteria(Expression<Func<Category, bool>> filterExpression);
        Task<Category> GetCategoryWithCriteriaAsync(Expression<Func<Category, bool>> filterExpression);
        Category AddCategoy(Category obj);
        Task<Category> AddCategoryAsync(Category obj);
        void UpdateCategory(Category obj);
        void DeleteCategory(object id);
        Task DeleteCategoryAsync(object id);
        void Save();
        Task SaveAsync();
    }
}