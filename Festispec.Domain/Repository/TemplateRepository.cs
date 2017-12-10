using System.Data.Entity;
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
            return base.Get().Include(template => template.Questions.Select(question => question.QuestionType));
        }

        public override int Delete(Template entity)
        {
            entity = CleanRelations(entity);
            return base.Delete(entity);
        }

        public void AddQuestion(Template template, TemplateQuestion templateQuestion)
        {
            templateQuestion.Template = null;
            template.Questions.Add(templateQuestion);
            DbContext.SaveChanges();
        }

        private Template CleanRelations(Template entity)
        {
            entity.Questions = null;
            return entity;
        }
    }
}