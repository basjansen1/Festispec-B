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

//        public override IQueryable<Template> Get()
//        {
//            return base.Get().Include(template => template.Questions.Select(question => question.QuestionType));
//        }
//
//        public override int Delete(Template entity)
//        {
//            entity = CleanRelations(entity);
//            return base.Delete(entity);
//        }
//
        public void AddQuestion(Template template, Question question)
        {
            if (question.Id == 0)
            {
                DbContext.Set<Question>().Add(question);
                DbContext.SaveChanges();
            }

            DbContext.Set<TemplateQuestion>()
                .Add(new TemplateQuestion {Template_Id = template.Id, Question_Id = question.Id});
            DbContext.SaveChanges();
        }
//
//        private Template CleanRelations(Template entity)
//        {
//            entity.Questions = null;
//            return entity;
//        }
    }
}