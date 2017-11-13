using System.Data.Entity;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository
{
    public class QuestionTypeRepository : RepositoryBase<QuestionType>, IQuestionTypeRepository
    {
        public QuestionTypeRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}