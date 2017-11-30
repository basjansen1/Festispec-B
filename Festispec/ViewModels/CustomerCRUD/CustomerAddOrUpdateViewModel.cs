using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using Festispec.NavigationService;
using Festispec.ViewModels.Customer;
using Festispec.ViewModels.Factory.Interface;
using System.ComponentModel;

namespace Festispec.ViewModels.CustomerCRUD
{
   public class CustomerAddOrUpdateViewModel :
        AddOrUpdateViewModelBase<ICustomerViewModelFactory, CustomerViewModel, ICustomerRepository, Domain.Customer>
    {
        public CustomerAddOrUpdateViewModel(INavigationService navigationService,
            ICustomerRepositoryFactory repositoryFactory,
            ICustomerViewModelFactory CustomerViewModelFactory)
            : base(navigationService, repositoryFactory, CustomerViewModelFactory)
        {
            RaisePropertyChanged();
        }

        public override void OnNavigationServicePropertyChange(object sender, PropertyChangedEventArgs args)
        {
            RaisePropertyChanged();
            if (args.PropertyName != "CurrentRoute") return;

            if (NavigationService.CurrentRoute != Routes.Routes.CustomerAddOrUpdate) return;

            UpdateEntityViewModelFromNavigationParameter();
        }

        public override void Save()
        {
            // TODO: Validation
            var saved = EntityViewModel.Save();
            RaisePropertyChanged();
            if (saved) NavigationService.GoBack(EntityViewModel);
        }
    }
}
