using Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProductService.Infrastructure
{
    public interface IProductService
    {
        List<Product> GetAllProduct();
        Task<List<Product>> GetAllProductAsync();
        Product GetByProductId(object id);
        Task<Product> GetByProductIdAsync(object id);
        Product GetProductWithCriteria(Expression<Func<Product, bool>> filterExpression);
        Task<Product> GetProductWithCriteriaAsync(Expression<Func<Product, bool>> filterExpression);
        List<Product> GetProductWithCriteriaAll(Expression<Func<Product, bool>> filterExpression);
        Task<List<Product>> GetProductWithCriteriaAllAsync(Expression<Func<Product, bool>> filterExpression);
        Product AddProduct(Product obj);
        Task<Product> AddProductAsync(Product obj);
        void UpdateProduct(Product obj);
        void DeleteProduct(object id);
        Task DeleteProductAsync(object id);
        void Save();
        Task SaveAsync();
    }
}