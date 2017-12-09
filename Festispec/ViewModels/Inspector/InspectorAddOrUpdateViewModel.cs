using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using Festispec.ViewModels.Factory.Interface;
using Festispec.NavigationService;
using GalaSoft.MvvmLight.CommandWpf;

namespace Festispec.ViewModels.Inspector
{
    public class InspectorAddOrUpdateViewModel :
        AddOrUpdateViewModelBase<IInspectorViewModelFactory, InspectorViewModel, IInspectorRepository, Domain.Inspector>
    {
        private readonly IGeoRepository _geoRepository;

        public InspectorAddOrUpdateViewModel(INavigationService navigationService,
            IInspectorRepositoryFactory repositoryFactory,
            IInspectorViewModelFactory inspectorViewModelFactory, IEmployeeRepositoryFactory employeeRepositoryFactory, IGeoRepository geoRepository)
            : base(navigationService, repositoryFactory, inspectorViewModelFactory)
        {
            _geoRepository = geoRepository;
            using (var employeeRepository = employeeRepositoryFactory.CreateRepository())
            {
                Managers = new[] {new Domain.Employee {Id = -1}}.Concat(employeeRepository.Get()
                    .Where(e => e.Role_Role == "Manager").ToList());
            }

            SearchAddressCommand = new RelayCommand(() => SearchAddress());
        }
        public ICommand SearchAddressCommand { get; set; }

        public IEnumerable<Domain.Employee> Managers { get; }

        public override void OnNavigationServicePropertyChange(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "CurrentRoute") return;

            if (NavigationService.CurrentRoute != Routes.Routes.InspectorAddOrUpdate) return;

            UpdateEntityViewModelFromNavigationParameter();
            UpdateInspectorFromNavigationParameter();
        }

        private void UpdateInspectorFromNavigationParameter()
        {
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
                catch (ArgumentNullException exception)
                {
                    switch (exception.ParamName)
                    {
                        case "PostalCode":
                        case "HouseNumber":
                            MessageBox.Show("Geef een postcode en huisnummer op");
                            break;
                        case "json":
                            MessageBox.Show(
                                $"Geen adres gevonden op {EntityViewModel.PostalCode} {EntityViewModel.HouseNumber}");
                            break;
                        default:
                            MessageBox.Show("Er is iets fout gegaan");
                            break;
                    }
                }
                catch (InvalidOperationException exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }

            return false;
        }

        public override void Save()
        {
            // TODO: Validation
            var saved = SearchAddress() && EntityViewModel.Save();

            // Return is save failed
            if (!saved)
                return;

            // Overwrite the original values with the new entity values
            EntityViewModel.MapValuesToOriginal();

            GoBack(EntityViewModel);
        }
    }
}