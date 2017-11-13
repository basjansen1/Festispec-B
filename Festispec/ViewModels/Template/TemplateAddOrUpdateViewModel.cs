using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.NavigationService;

namespace Festispec.ViewModels.Template
{
    public abstract class TemplateAddOrUpdateViewModel :
        AddOrUpdateViewModelBase<ITemplateViewModelFactory, TemplateViewModel, Domain.Template>
    {
        protected TemplateAddOrUpdateViewModel(INavigationService navigationService,
            ITemplateRepositoryFactory repositoryFactory, ITemplateViewModelFactory templateViewModelFactory)
            : base(navigationService, repositoryFactory, templateViewModelFactory)
        {
        }
    }
}