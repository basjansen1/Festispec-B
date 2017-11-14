﻿using System.Data.Entity;
using System.Linq;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository
{
    public class TemplateRepository : RepositoryBase<Template>, ITemplateRepository
    {
        public TemplateRepository(DbContext dbContext) : base(dbContext)
        {
        }
        

        public override IQueryable<Template> Get()
        {
            return base.Get().Include(template => template.Questions).AsNoTracking();
        }

        public override int Delete(Template entity)
        {
            foreach (var templateQuestion in entity.Questions.ToList())
            {
                DbContext.Set<TemplateQuestion>().Attach(templateQuestion);
                DbContext.Set<TemplateQuestion>().Remove(templateQuestion);
            }

            return base.Delete(entity);
        }
    }
}