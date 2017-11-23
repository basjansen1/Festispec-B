using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.Template;

namespace Festispec.ViewModels.Factory
{
    public class TemplateViewModelFactory :  ITemplateViewModelFactory
    {
        private readonly ITemplateRepositoryFactory _templateRepositoryFactory;
        private readonly ITemplateQuestionViewModelFactory _templateQuestionViewModelFactory;
        public TemplateViewModelFactory(ITemplateRepositoryFactory templateRepositoryFactory, ITemplateQuestionViewModelFactory templateQuestionViewModelFactory)
        {
            _templateRepositoryFactory = templateRepositoryFactory;
            _templateQuestionViewModelFactory = templateQuestionViewModelFactory;
        }

        public TemplateViewModel CreateViewModel()
        {
            return new TemplateViewModel(_templateRepositoryFactory, _templateQuestionViewModelFactory);
        }

        public TemplateViewModel CreateViewModel(Domain.Template entity)
        {
            return new TemplateViewModel(_templateRepositoryFactory, _templateQuestionViewModelFactory, entity);
        }
    }
}