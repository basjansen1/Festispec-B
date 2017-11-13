using System.ComponentModel;
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
        public override void OnNavigationServicePropertyChange(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "CurrentPageKey") return;

            if (NavigationService.CurrentPageKey != Routes.Routes.TemplateUpdate.Key &&
                NavigationService.CurrentPageKey != Routes.Routes.TemplateAdd.Key) return;

            UpdateEntityViewModelFromNavigationParameter();
        }
    }
}