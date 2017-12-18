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
            return base.Get().Include($"{nameof(TemplateQuestion)}.{nameof(Question)}.{nameof(QuestionType)}");
        }

        public override Template Add(Template entity)
        {
            entity = CleanRelations(entity);
            return base.Add(entity);
        }

        public override Template Update(Template updated, params object[] keyValues)
        {
            updated = CleanRelations(updated);
            return base.Update(updated, keyValues);
        }

        public override int Delete(Template entity)
        {
            entity = CleanRelations(entity);
            return base.Delete(entity);
        }

        public void TryAttachQuestion(Template template, Question question)
        {
            var exists = DbContext.Set<TemplateQuestion>().Any(templateQuestion =>
                templateQuestion.Template_Id == template.Id && templateQuestion.Question_Id == question.Id);

            if (exists)
                return;

            AttachQuestions(template, question);
        }

        public void AttachQuestions(Template template, Question question)
        {
            DbContext.Set<TemplateQuestion>()
                .Add(new TemplateQuestion {Template_Id = template.Id, Question_Id = question.Id});
            DbContext.SaveChanges();
        }

        public void DetachQuestions(Template template, Question question)
        {
            var existing = DbContext.Set<TemplateQuestion>().Find(template.Id, question.Id);

            if (existing == null) return;

            DbContext.Entry(existing).State = EntityState.Deleted;
            DbContext.SaveChanges();
        }

        private static Template CleanRelations(Template entity)
        {
            entity.TemplateQuestion = null;
            return entity;
        }
    }
}