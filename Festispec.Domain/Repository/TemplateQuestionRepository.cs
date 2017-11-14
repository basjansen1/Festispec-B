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
        
        public override IQueryable<TemplateQuestion> Get()
        {
            return base.Get().Include(templateQuestion => templateQuestion.QuestionType).AsNoTracking();
        }
    }
}