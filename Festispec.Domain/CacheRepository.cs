using Festispec.Domain.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Festispec.Domain
{
    class CacheRepository<T> : IRepository<T>
    {
        protected IRepository<T> baserepository;
        protected List<T> list;
        public T Add(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public T AddOrUpdate(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> AddOrUpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public int Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public T Find(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public ICollection<T> FindAll(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Get()
        {
            throw new NotImplementedException();
        }

        public T Get(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public T Update(T updated, params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T updated, params object[] keyValues)
        {
            throw new NotImplementedException();
        }
    }
}
