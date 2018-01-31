using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository.Factory
{
    public class QuestionRepositoryFactory : RepositoryFactoryBase<IQuestionRepository, Question>,
        IQuestionRepositoryFactory
    {
        public QuestionRepositoryFactory(bool isOnline) : base(isOnline)
        {
        }

        public override IQuestionRepository CreateRepository()
        {
            return new QuestionRepository(GetDbContext());
        }
    }
}