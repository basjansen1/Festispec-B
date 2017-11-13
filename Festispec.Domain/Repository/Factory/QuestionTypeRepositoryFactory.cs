using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository.Factory
{
    public class QuestionTypeRepositoryFactory : RepositoryFactoryBase<QuestionType>, IQuestionTypeRepositoryFactory
    {
        public override IRepository<QuestionType> CreateRepository()
        {
            return new QuestionTypeRepository(GetDbContext());
        }
    }
}