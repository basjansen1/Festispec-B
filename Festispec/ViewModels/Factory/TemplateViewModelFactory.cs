using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.Template;

namespace Festispec.ViewModels.Factory
{
    public class TemplateViewModelFactory :  ITemplateViewModelFactory
    {
        private readonly ITemplateRepositoryFactory _templateRepositoryFactory;
        private readonly IQuestionViewModelFactory _questionViewModelFactory;
        public TemplateViewModelFactory(ITemplateRepositoryFactory templateRepositoryFactory, IQuestionViewModelFactory questionViewModelFactory)
        {
            _templateRepositoryFactory = templateRepositoryFactory;
            _questionViewModelFactory = questionViewModelFactory;
        }

        public TemplateViewModel CreateViewModel()
        {
            return new TemplateViewModel(_templateRepositoryFactory, _questionViewModelFactory);
        }

        public TemplateViewModel CreateViewModel(Domain.Template entity)
        {
            return new TemplateViewModel(_templateRepositoryFactory, _questionViewModelFactory, entity);
        }
    }
}