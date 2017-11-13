using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.Template;

namespace Festispec.ViewModels.Factory
{
    public class TemplateQuestionViewModelFactory :  ITemplateQuestionViewModelFactory
    {
        private readonly ITemplateQuestionRepositoryFactory _templateQuestionRepositoryFactory;
        public TemplateQuestionViewModelFactory(ITemplateQuestionRepositoryFactory templateQuestionRepositoryFactory)
        {
            _templateQuestionRepositoryFactory = templateQuestionRepositoryFactory;
        }

        public TemplateQuestionViewModel CreateViewModel()
        {
            return new TemplateQuestionViewModel(_templateQuestionRepositoryFactory);
        }

        public TemplateQuestionViewModel CreateViewModel(Domain.TemplateQuestion entity)
        {
            return new TemplateQuestionViewModel(_templateQuestionRepositoryFactory, entity);
        }
    }
}