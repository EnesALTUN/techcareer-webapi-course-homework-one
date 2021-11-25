using CategoryService.Infrastructure;
using Entities;
using Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _categoryRepository;

        public CategoryService(IGenericRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> AddCategoryAsync(Category obj)
        {
            await _categoryRepository.InsertAsync(obj);

            return obj;
        }

        public Category AddCategoy(Category obj)
        {
            _categoryRepository.Insert(obj);

            return obj;
        }

        public void DeleteCategory(object id)
        {
            _categoryRepository.Delete(id);
        }

        public async Task DeleteCategoryAsync(object id)
        {
            await _categoryRepository.DeleteAsync(id);
        }

        public List<Category> GetAllCategory()
        {
            return _categoryRepository.GetAll();
        }

        public Task<List<Category>> GetAllCategoryAsync()
        {
            return _categoryRepository.GetAllAsync();
        }

        public Category GetByCategoryId(object id)
        {
            return _categoryRepository.GetById(id);
        }

        public async Task<Category> GetByCategoryIdAsync(object id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        public Category GetCategoryWithCriteria(Expression<Func<Category, bool>> filterExpression)
        {
            return _categoryRepository.GetWithCriteria(filterExpression);
        }

        public Task<Category> GetCategoryWithCriteriaAsync(Expression<Func<Category, bool>> filterExpression)
        {
            return _categoryRepository.GetWithCriteriaAsync(filterExpression);
        }

        public void Save()
        {
            _categoryRepository.Save();
        }

        public async Task SaveAsync()
        {
            await _categoryRepository.SaveAsync();
        }

        public void UpdateCategory(Category obj)
        {
            _categoryRepository.Update(obj);
        }
    }
}