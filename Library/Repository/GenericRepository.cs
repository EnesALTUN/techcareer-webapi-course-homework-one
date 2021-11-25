﻿using Data;
using Microsoft.EntityFrameworkCore;
using Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly HomeworkDbContext _context;
        private readonly DbSet<TEntity> table;

        public GenericRepository(HomeworkDbContext context)
        {
            _context = context;
            table = _context.Set<TEntity>();
        }

        public List<TEntity> GetAll()
        {
            return table.ToList();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await table.ToListAsync();
        }

        public TEntity GetById(object id)
        {
            return table.Find(id);
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await table.FindAsync(id);
        }

        public TEntity GetWithCriteria(Expression<Func<TEntity, bool>> filterExpression)
        {
            return table.Where(filterExpression).FirstOrDefault();
        }

        public async Task<TEntity> GetWithCriteriaAsync(Expression<Func<TEntity, bool>> filterExpression)
        {
            return await table.Where(filterExpression).FirstOrDefaultAsync();
        }

        public List<TEntity> GetWithCriteriaAll(Expression<Func<TEntity, bool>> filterExpression)
        {
            return table.Where(filterExpression).ToList();
        }

        public async Task<List<TEntity>> GetWithCriteriaAllAsync(Expression<Func<TEntity, bool>> filterExpression)
        {
            return await table.Where(filterExpression).ToListAsync();
        }

        public void Insert(TEntity obj)
        {
            table.Add(obj);
        }

        public async Task InsertAsync(TEntity obj)
        {
            await table.AddAsync(obj);
        }

        public void Update(TEntity obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            TEntity exist = table.Find(id);
            table.Remove(exist);
        }

        public async Task DeleteAsync(object id)
        {
            TEntity exist = await table.FindAsync(id);
            table.Remove(exist);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}