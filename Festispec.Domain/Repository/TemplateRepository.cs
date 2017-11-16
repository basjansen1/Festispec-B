using System.Data.Entity;
using System.Data.Entity.Migrations;
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
            return base.Get().Include(template => template.Questions.Select(question => question.QuestionType)).AsNoTracking();
        }

        public override Template AddOrUpdate(Template entity)
        {
            foreach (var templateQuestion in entity.Questions)
            {
                DbContext.Entry(templateQuestion.Template);
                if (templateQuestion.IsDeleted)
                {
                    DbContext.Set<TemplateQuestion>().Remove(templateQuestion);
                }
                else
                {
                    if(DbContext.Set<QuestionType>().Local.Any(questionType => questionType.Type == templateQuestion.QuestionType.Type)) DbContext.Entry(templateQuestion.QuestionType).State = EntityState.Unchanged;
                    DbContext.Set<TemplateQuestion>().AddOrUpdate(templateQuestion);
                }
                
            }
            DbContext.SaveChanges();

            return base.AddOrUpdate(entity);
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