using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository.Factory
{
    public class QuestionTypeRepositoryFactory : RepositoryFactoryBase<IQuestionTypeRepository, QuestionType>, IQuestionTypeRepositoryFactory
    {
        public QuestionTypeRepositoryFactory(bool isOnline) : base(isOnline)
        {
        }

        public override IQuestionTypeRepository CreateRepository()
        {
            return new QuestionTypeRepository(GetDbContext());
        }
    }
}