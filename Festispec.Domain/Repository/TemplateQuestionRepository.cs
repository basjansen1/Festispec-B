using System.Data.Entity;
using System.Linq;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository
{
    public class TemplateQuestionRepository : RepositoryBase<TemplateQuestion>, ITemplateQuestionRepository
    {
        public TemplateQuestionRepository(DbContext dbContext) : base(dbContext)
        {
        }


        IQueryable<TemplateQuestion> IRepository<TemplateQuestion>.Get()
        {
            return Get().Include(templateQuestion => templateQuestion.QuestionType).AsNoTracking();
        }

        TemplateQuestion IRepository<TemplateQuestion>.Add(TemplateQuestion entity)
        {
            // Set relations to unchanged to prevent updating them
            _dbContext.Entry(entity.QuestionType).State = EntityState.Unchanged;
            _dbContext.Entry(entity.Template).State = EntityState.Unchanged;

            return Add(entity);
        }
    }
}