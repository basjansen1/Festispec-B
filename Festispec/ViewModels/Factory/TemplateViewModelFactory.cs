using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.Template;

namespace Festispec.ViewModels.Factory
{
    public class TemplateViewModelFactory :  ITemplateViewModelFactory
    {
        private readonly ITemplateRepositoryFactory _templateRepositoryFactory;
        public TemplateViewModelFactory(ITemplateRepositoryFactory templateRepositoryFactory)
        {
            _templateRepositoryFactory = templateRepositoryFactory;
        }

        public TemplateViewModel CreateViewModel()
        {
            return new TemplateViewModel(_templateRepositoryFactory);
        }

        public TemplateViewModel CreateViewModel(Template.Template entity)
        {
            return new TemplateViewModel(_templateRepositoryFactory, entity);
        }
    }
}