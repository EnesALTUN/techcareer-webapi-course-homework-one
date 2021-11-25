using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository.Infrastructure
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        List<TEntity> GetAll();
        Task<List<TEntity>> GetAllAsync();
        TEntity GetById(object id);
        Task<TEntity> GetByIdAsync(object id);
        TEntity GetWithCriteria(Expression<Func<TEntity, bool>> filterExpression);
        Task<TEntity> GetWithCriteriaAsync(Expression<Func<TEntity, bool>> filterExpression);
        List<TEntity> GetWithCriteriaAll(Expression<Func<TEntity, bool>> filterExpression);
        Task<List<TEntity>> GetWithCriteriaAllAsync(Expression<Func<TEntity, bool>> filterExpression);
        void Insert(TEntity obj);
        Task InsertAsync(TEntity obj);
        void Update(TEntity obj);
        void Delete(object id);
        Task DeleteAsync(object id);
        void Save();
        Task SaveAsync();
    }
}
