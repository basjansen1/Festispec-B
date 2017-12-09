using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using Festispec.NavigationService;
using Festispec.ViewModels.Customer;
using Festispec.ViewModels.Factory.Interface;
using GalaSoft.MvvmLight.Command;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Festispec.ViewModels.CustomerCRUD
{
   public class CustomerAddOrUpdateViewModel :
        AddOrUpdateViewModelBase<ICustomerViewModelFactory, CustomerViewModel, ICustomerRepository, Domain.Customer>
    {

        IGeoRepository _geoRepository;
        public ICommand SearchAddressCommand { get; set; }

        public CustomerAddOrUpdateViewModel(INavigationService navigationService,
            ICustomerRepositoryFactory repositoryFactory,
            ICustomerViewModelFactory CustomerViewModelFactory, IGeoRepository geoRepository)
            : base(navigationService, repositoryFactory, CustomerViewModelFactory)
        {
            _geoRepository = geoRepository;
            RaisePropertyChanged();
            SearchAddressCommand = new RelayCommand(() => SearchAddress());
        }

        public override void OnNavigationServicePropertyChange(object sender, PropertyChangedEventArgs args)
        {
            RaisePropertyChanged();
            if (args.PropertyName != "CurrentRoute") return;

            if (NavigationService.CurrentRoute != Routes.Routes.CustomerAddOrUpdate) return;

            UpdateEntityViewModelFromNavigationParameter();
        }

        private bool SearchAddress()
        {
            using (_geoRepository)
            {
                try
                {
                    var address = _geoRepository.Find(EntityViewModel.PostalCode,
                        EntityViewModel.HouseNumber);

                    EntityViewModel.Street = address.Street;
                    EntityViewModel.City = address.City;
                    EntityViewModel.Municipality = address.Municipality;
                    EntityViewModel.Country = address.Country;
                    EntityViewModel.Lat = address.Lat;
                    EntityViewModel.Long = address.Long;
                    EntityViewModel.Location = address.Location;

                    return true;
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
            return false;
        }

        public override void Save()
        {
            if (SearchAddress())
                return;

            // TODO: Validation

            base.Save();
        }
    }
}
