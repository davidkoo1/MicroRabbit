using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Banking.Infrastructure.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public readonly ILogger _logger;
        protected BankingDbContext _dbContext;
        internal DbSet<TEntity> _dbSet;

        public GenericRepository(BankingDbContext dbContext, ILogger logger)
        {
            _dbContext = dbContext;
            _logger = logger;

            _dbSet = dbContext.Set<TEntity>();
        }

        public virtual async Task<bool> Add(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return await Save();
        }

        public virtual async Task<bool> Delete(int id)
        {
            var entity = await _dbSet.FindAsync(id);

            if(entity == null) return false;

            _dbSet.Remove(entity);
            return await Save();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll() => await _dbSet.ToListAsync();

        public virtual async Task<TEntity?> GetById(int id) => await _dbSet.FindAsync(id);

        public virtual async Task<bool> Save() => await _dbContext.SaveChangesAsync() > 0;

        public virtual async Task<bool> Update(TEntity entity)
        {
            var existingEntity = await _dbSet.FindAsync(_dbContext.Entry(entity).Property("Id").CurrentValue);

            if (existingEntity == null) return false;

            _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
            _dbSet.Update(existingEntity);
            return await Save();
        }
    }
}
