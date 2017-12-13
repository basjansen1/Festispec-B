using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Festispec.Domain;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Test.DummyRepository
{
    public class DummyQuestionRepository : IQuestionRepository
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Question> Get()
        {
            throw new NotImplementedException();
        }

        public Question Get(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public Task<Question> GetAsync(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public Question Find(Expression<Func<Question, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Question> FindAsync(Expression<Func<Question, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public ICollection<Question> FindAll(Expression<Func<Question, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Question>> FindAllAsync(Expression<Func<Question, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Question Add(Question entity)
        {
            throw new NotImplementedException();
        }

        public Task<Question> AddAsync(Question entity)
        {
            throw new NotImplementedException();
        }

        public Question Update(Question updated, params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public Task<Question> UpdateAsync(Question updated, params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public Question AddOrUpdate(Question entity)
        {
            throw new NotImplementedException();
        }

        public Task<Question> AddOrUpdateAsync(Question entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(Question entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Question entity)
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
    }
}