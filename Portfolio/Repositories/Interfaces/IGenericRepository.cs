using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Portfolio.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Create(TEntity item);
        Task<TEntity> FindById(int id);
        Task<IEnumerable<TEntity>> Get();
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> Remove(TEntity item);
        Task<TEntity> Update(TEntity item);
    }
}
