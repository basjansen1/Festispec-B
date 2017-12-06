using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using Festispec.NavigationService;
using Festispec.ViewModels.Customer;
using Festispec.ViewModels.Factory.Interface;
using GalaSoft.MvvmLight.Command;
using System;
using System.ComponentModel;
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

                    return true;
                }
                catch (ArgumentNullException exception)
                {
                    //switch (exception.ParamName)
                    //{
                        //case "PostalCode":
                        //case "HouseNumber":
                          //  MessageBox.Show("Geef een postcode en huisnummer op");
                         //   break;
                       // case "json":
                           // MessageBox.Show(
                            //    $"Geen adres gevonden op {NewInspection.PostalCode} {NewInspection.HouseNumber}");
                          //  break;
                        //default:
                       //     MessageBox.Show("Er is iets fout gegaan");
                     //       break;
                   // }
                }
                catch (InvalidOperationException exception)
                {
                 //   MessageBox.Show(exception.Message);
                }
            }

            return false;
        }



        public override void Save()
        {
            // TODO: Validation
            var saved = SearchAddress() && EntityViewModel.Save();
            RaisePropertyChanged();
            if (saved) NavigationService.GoBack(EntityViewModel);
        }
    }
}
