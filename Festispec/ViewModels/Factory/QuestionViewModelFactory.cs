using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.Question;

namespace Festispec.ViewModels.Factory
{
    public class QuestionViewModelFactory : IQuestionViewModelFactory
    {
        private readonly IQuestionRepositoryFactory _customerRepositoryFactory;

        public QuestionViewModelFactory(IQuestionRepositoryFactory questionRepositoryFactory)
        {
            _customerRepositoryFactory = questionRepositoryFactory;
        }

        public QuestionViewModel CreateViewModel()
        {
            return new QuestionViewModel(_customerRepositoryFactory);
        }

        public QuestionViewModel CreateViewModel(Domain.Question entity)
        {
            return new QuestionViewModel(_customerRepositoryFactory, entity);
        }
    }
}