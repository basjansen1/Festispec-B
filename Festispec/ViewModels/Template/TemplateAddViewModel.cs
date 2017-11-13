using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.NavigationService;

namespace Festispec.ViewModels.Template
{
    public class TemplateAddViewModel : TemplateAddOrUpdateViewModel
    {
        public TemplateAddViewModel(INavigationService navigationService,
            ITemplateRepositoryFactory repositoryFactory, ITemplateViewModelFactory templateViewModelFactory)
            : base(navigationService, repositoryFactory, templateViewModelFactory)
        {
        }
    }
}