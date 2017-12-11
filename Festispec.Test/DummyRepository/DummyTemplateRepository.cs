using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Festispec.Domain;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Test.DummyRepository
{
    public class DummyTemplateRepository : ITemplateRepository
    {
        private readonly ICollection<Template> _templates = new List<Template>
        {
            new Template
            {
                Id = 1,
                Name = "Standaard Festival In de zomer",
                Description = "Deze template is bedoeld voor een standaard festival zomers"
            },
            new Template
            {
                Id = 2,
                Name = "Techno Festival",
                Description = "Deze template is bedoeld voor een techno festival"
            },
            new Template {Id = 3, Name = "Eet Festival", Description = "Deze template is bedoeld voor eetfestivals"}
        };

        public void Dispose()
        {
            // Do nothing because we want to persist the dummy data
        }

        public IQueryable<Template> Get()
        {
            return new EnumerableQuery<Template>(_templates);
        }

        public Template Get(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public Task<Template> GetAsync(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public Template Find(Expression<Func<Template, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Template> FindAsync(Expression<Func<Template, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public ICollection<Template> FindAll(Expression<Func<Template, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Template>> FindAllAsync(Expression<Func<Template, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Template Add(Template entity)
        {
            throw new NotImplementedException();
        }

        public Task<Template> AddAsync(Template entity)
        {
            throw new NotImplementedException();
        }

        public Template Update(Template updated, params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public Task<Template> UpdateAsync(Template updated, params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public Template AddOrUpdate(Template entity)
        {
            throw new NotImplementedException();
        }

        public Task<Template> AddOrUpdateAsync(Template entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(Template entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Template entity)
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

        public void TryAttachQuestion(Template template, Question question)
        {
            throw new NotImplementedException();
        }

        public void AttachQuestions(Template template, Question question)
        {
            throw new NotImplementedException();
        }

        public void DetachQuestions(Template template, Question question)
        {
            throw new NotImplementedException();
        }
    }
}