using Entities;
using ProductService.Infrastructure;
using Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProductService
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _productRepository;

        public ProductService(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public Product AddProduct(Product obj)
        {
            _productRepository.Insert(obj);

            return obj;
        }

        public async Task<Product> AddProductAsync(Product obj)
        {
            await _productRepository.InsertAsync(obj);

            return obj;
        }

        public void DeleteProduct(object id)
        {
            _productRepository.Delete(id);
        }

        public async Task DeleteProductAsync(object id)
        {
            await _productRepository.DeleteAsync(id);
        }

        public List<Product> GetAllProduct()
        {
            return _productRepository.GetAll();
        }

        public async Task<List<Product>> GetAllProductAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public Product GetByProductId(object id)
        {
            return _productRepository.GetById(id);
        }

        public async Task<Product> GetByProductIdAsync(object id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public Product GetProductWithCriteria(Expression<Func<Product, bool>> filterExpression)
        {
            return _productRepository.GetWithCriteria(filterExpression);
        }

        public async Task<Product> GetProductWithCriteriaAsync(Expression<Func<Product, bool>> filterExpression)
        {
            return await _productRepository.GetWithCriteriaAsync(filterExpression);
        }

        public List<Product> GetProductWithCriteriaAll(Expression<Func<Product, bool>> filterExpression)
        {
            return _productRepository.GetWithCriteriaAll(filterExpression);
        }

        public async Task<List<Product>> GetProductWithCriteriaAllAsync(Expression<Func<Product, bool>> filterExpression)
        {
            return await _productRepository.GetWithCriteriaAllAsync(filterExpression);
        }

        public void Save()
        {
            _productRepository.Save();
        }

        public async Task SaveAsync()
        {
            await _productRepository.SaveAsync();
        }

        public void UpdateProduct(Product obj)
        {
            _productRepository.Update(obj);
        }
    }
}