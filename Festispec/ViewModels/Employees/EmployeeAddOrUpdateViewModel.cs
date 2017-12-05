using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using Festispec.NavigationService;
using Festispec.ViewModels.Employee;
using Festispec.ViewModels.Factory.Interface;
using GalaSoft.MvvmLight.CommandWpf;

namespace Festispec.ViewModels.Employees
{
    public class EmployeeAddOrUpdateViewModel :
        AddOrUpdateViewModelBase<IEmployeeViewModelFactory, EmployeeViewModel, IEmployeeRepository, Domain.Employee>
    {
        private readonly IGeoRepository _geoRepository;

        public EmployeeAddOrUpdateViewModel(INavigationService navigationService,
            IEmployeeRepositoryFactory repositoryFactory,
            IEmployeeRoleRepositoryFactory employeeRoleRepositoryFactory,
            IEmployeeViewModelFactory employeeViewModelFactory, IGeoRepository geoRepository)
            : base(navigationService, repositoryFactory, employeeViewModelFactory)
        {
            _geoRepository = geoRepository;
            using (var employeeRepository = repositoryFactory.CreateRepository())
            {
                Managers = new[] {new Domain.Employee {Id = -1}}.Concat(employeeRepository.Get()
                    .Where(e => e.Role_Role == "Manager" && e.Id != EntityViewModel.Id).ToList());
            }
            using (var employeeRoleRepository = employeeRoleRepositoryFactory.CreateRepository())
            {
                Roles = employeeRoleRepository.Get().Where(e => e.Role != "Inspecteur").ToList();
            }

            SearchAddressCommand = new RelayCommand(() => SearchAddress());
        }

        private bool SearchAddress()
        {
            using (_geoRepository)
            {
                try
                {
                    var address = _geoRepository.Find(EntityViewModel.PostalCode,
                        EntityViewModel.HouseNumber);
                    
                    EntityViewModel.Street = EntityViewModel.Street = address.Street;
                    EntityViewModel.City = EntityViewModel.City = address.City;
                    EntityViewModel.Municipality = EntityViewModel.Municipality = address.Municipality;
                    EntityViewModel.Country = EntityViewModel.Country = address.Country;

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

        public IEnumerable<Domain.Employee> Managers { get; }
        public IEnumerable<EmployeeRole> Roles { get; }

        public ICommand SearchAddressCommand { get; set; }

        public override void OnNavigationServicePropertyChange(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "CurrentRoute") return;

            if (NavigationService.CurrentRoute != Routes.Routes.EmployeeAddOrUpdate) return;

            UpdateEntityViewModelFromNavigationParameter();
        }

        public override void Save()
        {
            if (EntityViewModel.Manager_Id == -1)
            {
                EntityViewModel.Manager = null;
                EntityViewModel.Manager_Id = null;
            }

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