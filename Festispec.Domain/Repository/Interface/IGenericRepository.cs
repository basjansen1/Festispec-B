using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Festispec.Domain.Repository.Interface
{
    public interface IGenericRepository<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> Get();

        TEntity Get(params object[] keyValues);

        Task<TEntity> GetAsync(params object[] keyValues);

        TEntity Find(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);

        ICollection<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate);

        Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate);

        TEntity Add(TEntity entity);

        Task<TEntity> AddAsync(TEntity entity);

        TEntity Update(TEntity updated, params object[] keyValues);

        Task<TEntity> UpdateAsync(TEntity updated, params object[] keyValues);

        int Delete(TEntity entity);

        Task<int> DeleteAsync(TEntity entity);

        int Count();

        Task<int> CountAsync();
    }
}