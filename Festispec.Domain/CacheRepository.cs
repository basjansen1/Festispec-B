//using Festispec.Domain.Repository.Interface;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Linq.Expressions;
//using System.Collections.ObjectModel;

//namespace Festispec.Domain
//{
//    class CacheRepository<T> : IRepository<T> where T : class
//    {
//        protected IRepository<T> _baserepository;
//        protected Collection<T> _cache;

//        public T Add(T entity)
//        {
            
//            EnumerableQuery<T> list = new EnumerableQuery<T>(_cache.GetEnumerator());
//            return _baserepository.Add(entity);
//        }

//        public Task<T> AddAsync(T entity)
//        {
//            return _baserepository.AddAsync(entity);
//        }

//        public T AddOrUpdate(T entity)
//        {
//            return _baserepository.AddOrUpdate(entity);
//        }

//        public Task<T> AddOrUpdateAsync(T entity)
//        {
//            return _baserepository.AddOrUpdateAsync(entity);
//        }

//        public int Count()
//        {
//            try
//            {
//                return _baserepository.Count();
//            }
//            catch
//            {
//                return _cache.Count;
//            }
//        }

//        public Task<int> CountAsync()
//        {
//            try
//            {
//                return _baserepository.CountAsync();
//            }
//            catch(Exception e)
//            {
//                throw new NotSupportedException("Not supported for cache", e);
//            }
//        }

//        public int Delete(T entity)
//        {
//            return _baserepository.Delete(entity);
//        }

//        public Task<int> DeleteAsync(T entity)
//        {
//            return _baserepository.DeleteAsync(entity);
//        }

//        public void Dispose()
//        {
//             _baserepository.Dispose();
//        }

//        public T Find(Expression<Func<T, bool>> predicate)
//        {
//            try
//            {
//                return _baserepository.Find(predicate);
//            }
//            catch
//            {
//                return _cache.SingleOrDefault(predicate);
//            }
            
//        }

//        public ICollection<T> FindAll(Expression<Func<T, bool>> predicate)
//        {
//            try
//            {
//                return _baserepository.FindAll(predicate);
//            }
//            catch
//            {
//                return _cache.Where(predicate);
//            }

//        }

//        public Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> predicate)
//        {
//            return _baserepository.FindAllAsync(predicate);
//        }

//        public Task<T> FindAsync(Expression<Func<T, bool>> predicate)
//        {
//            return _baserepository.FindAsync(predicate);
//        }

//        public IQueryable<T> Get()
//        {
//            return _baserepository.Get();
//        }

//        public T Get(params object[] keyValues)
//        {
//            return _baserepository.Get(keyValues);
//        }

//        public Task<T> GetAsync(params object[] keyValues)
//        {
//            return _baserepository.GetAsync(keyValues);
//        }

//        public T Update(T updated, params object[] keyValues)
//        {
//            return _baserepository.Update(updated, keyValues);
//        }

//        public Task<T> UpdateAsync(T updated, params object[] keyValues)
//        {
//            return _baserepository.UpdateAsync(updated, keyValues);
//        }
//    }
//}
