using Microsoft.EntityFrameworkCore;
using Portfolio.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Portfolio.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        PortfolioContext _context;
        DbSet<TEntity> _dbSet;

        public GenericRepository(PortfolioContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Get()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }
        public async Task<TEntity> FindById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<TEntity> Create(TEntity item)
        {
            await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();

            return item;
        }
        public async Task<TEntity> Update(TEntity item)
        {
            //_context.Entry(item).State = EntityState.Modified;
            _dbSet.Update(item);
            await _context.SaveChangesAsync();

            return item;

        }
        public async Task<TEntity> Remove(TEntity item)
        {
            _dbSet.Remove(item);
            await _context.SaveChangesAsync();

            return item;
        }
    }
}
