using System.Data.Entity;
using System.Linq;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository
{
    public class QuestionTypeRepository : RepositoryBase<QuestionType>, IQuestionTypeRepository
    {
        public QuestionTypeRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<QuestionType> Get()
        {
            return base.Get().Include(questionType => questionType.Questions).AsNoTracking();
        }
    }
}