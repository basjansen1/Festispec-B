using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Festispec.Domain;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Test.DummyRepository
{
    internal class DummyTemplateQuestionRepository : ITemplateQuestionRepository
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TemplateQuestion> Get()
        {
            throw new NotImplementedException();
        }

        public TemplateQuestion Get(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public Task<TemplateQuestion> GetAsync(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public TemplateQuestion Find(Expression<Func<TemplateQuestion, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<TemplateQuestion> FindAsync(Expression<Func<TemplateQuestion, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public ICollection<TemplateQuestion> FindAll(Expression<Func<TemplateQuestion, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<TemplateQuestion>> FindAllAsync(Expression<Func<TemplateQuestion, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TemplateQuestion Add(TemplateQuestion entity)
        {
            throw new NotImplementedException();
        }

        public Task<TemplateQuestion> AddAsync(TemplateQuestion entity)
        {
            throw new NotImplementedException();
        }

        public TemplateQuestion Update(TemplateQuestion updated, params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public Task<TemplateQuestion> UpdateAsync(TemplateQuestion updated, params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public TemplateQuestion AddOrUpdate(TemplateQuestion entity)
        {
            throw new NotImplementedException();
        }

        public Task<TemplateQuestion> AddOrUpdateAsync(TemplateQuestion entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(TemplateQuestion entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(TemplateQuestion entity)
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