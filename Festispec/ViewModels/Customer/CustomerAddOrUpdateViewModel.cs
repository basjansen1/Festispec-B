using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using Festispec.NavigationService;
using Festispec.ViewModels.Factory.Interface;
using System.ComponentModel;
using Festispec.ViewModels.Address;

namespace Festispec.ViewModels.Customer
{
   public class CustomerAddOrUpdateViewModel :
        AddressAddOrUpdateViewModelBase<ICustomerViewModelFactory, CustomerViewModel, ICustomerRepository, Domain.Customer>
    {
        public CustomerAddOrUpdateViewModel(INavigationService navigationService,
            ICustomerRepositoryFactory repositoryFactory,
            ICustomerViewModelFactory CustomerViewModelFactory, IGeoRepositoryFactory geoRepositoryFactory)
            : base(navigationService, repositoryFactory, CustomerViewModelFactory, geoRepositoryFactory)
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

            base.Save();
        }
    }
}
