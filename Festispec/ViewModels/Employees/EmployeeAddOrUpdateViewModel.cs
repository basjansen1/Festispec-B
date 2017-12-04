﻿using System;
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

            SearchAddressCommand = new RelayCommand(SearchAddress);
        }

        private void SearchAddress()
        {
            using (_geoRepository)
            {
                try
                {
                    var address = _geoRepository.Find(EntityViewModel.UpdatedEntity.PostalCode,
                        EntityViewModel.UpdatedEntity.HouseNumber);

                    EntityViewModel.PostalCode = EntityViewModel.UpdatedEntity.PostalCode = address.PostalCode;
                    EntityViewModel.HouseNumber = EntityViewModel.UpdatedEntity.HouseNumber = address.HouseNumber;
                    EntityViewModel.Street = EntityViewModel.UpdatedEntity.Street = address.Street;
                    EntityViewModel.City = EntityViewModel.UpdatedEntity.City = address.City;
                    EntityViewModel.Municipality = EntityViewModel.UpdatedEntity.Municipality = address.Municipality;
                    EntityViewModel.Country = EntityViewModel.UpdatedEntity.Country = address.Country;
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
                                $"Geen adres gevonden op {EntityViewModel.UpdatedEntity.PostalCode} {EntityViewModel.UpdatedEntity.HouseNumber}");
                            break;
                        default:
                            MessageBox.Show("Er is iets fout gegaan");
                            break;
                    }
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show($"{EntityViewModel.PostalCode} is geen geldige postcode");
                }
            }
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
            var saved = EntityViewModel.Save();

            if(saved) NavigationService.GoBack(EntityViewModel);
        }
    }
}