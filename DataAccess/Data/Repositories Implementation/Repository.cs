using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness_Core;
using Bussiness_Core.IRepositories;
using DataAccess.Data.DataContext_Class;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data.Repositories_Implementation
{
    public class Repository<TKey, TEntity> : IRepository<TKey, TEntity> where TEntity : class
    {
        private readonly DbContext _Context;

        public Repository(DbContext Context)
        {
            _Context = Context;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
          await _Context.Set<TEntity>().AddRangeAsync(entity);
            return entity;
        }

        public void DeleteAsync(TEntity entity)
        {
            _Context.Set<TEntity>().RemoveRange(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllSync()
        {
            return await _Context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByKeyAsync(TKey Id)
        {
            return await _Context.Set<TEntity>().FindAsync(Id);
        }

        public void UpdateSync(TEntity entity)
        {
             _Context.Set<TEntity>().UpdateRange(entity);
        }
    }
}
