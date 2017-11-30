using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.InspectionProcessing;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Festispec.NavigationService;

namespace Festispec.ViewModels.Employees
{
    public class AddInspectionVM : ViewModelBase
    {
        // properties
        public InspectionListVM InspectionList { get; set; }
        public InspectionVM NewInspection { get; set; }
        public List<CustomerVM> CustomerList { get; set; }
        public List<string> CustomerNames { get; set; }
        public int SelectedIndexCustomerList
        {
            get
            {
                return _selectedIndexCustomerList;
            }
            set
            {
                _selectedIndexCustomerList = value;
                NewInspection.Customer = CustomerList.ElementAt(_selectedIndexCustomerList).ToModel();
                RaisePropertyChanged("customer");
            }
        }
        public ICommand AddInspectionCommand { get; set; }
        public ICommand CloseWindowCommand { get; set; }
        private readonly INavigationService _navigationService;

        // constructor
        public AddInspectionVM(InspectionListVM inspectionList, ICustomerRepositoryFactory customerRepositoryFactory, INavigationService navigationService)
        {
            InspectionList = inspectionList;
            _navigationService = navigationService;
            NewInspection = new InspectionVM();
            NewInspection.Status = "Pending";
            NewInspection.StartDate = new DateTime(2017, 01, 12);
            NewInspection.EndDate = new DateTime(2017, 01, 12);

            NewInspection.Location = DbGeography.PointFromText("POINT(50 5)", 4326);
            CustomerList = new List<CustomerVM>();
            CustomerNames = new List<string>();
            
            AddInspectionCommand = new RelayCommand(AddInspection);
            CloseWindowCommand = new RelayCommand(_navigationService.GoBack); 

            using(var customerRepository = customerRepositoryFactory.CreateRepository())
            {
                customerRepository.Get().ToList().ForEach(c => CustomerList.Add(new CustomerVM(c)));
            }
            CustomerList.ForEach(c => CustomerNames.Add(c.Name));

            if (CustomerList.Any())
            {
                NewInspection.Customer = CustomerList.ElementAt(0).ToModel();
            }
        }

        // fields
        private int _selectedIndexCustomerList;

        // methods
        public bool CanAddInspection()
        {
            if (NewInspection.Name != null && NewInspection.StartDate != null
                && NewInspection.EndDate != null && NewInspection.Website != null
                && NewInspection.Status != null && NewInspection.Street != null
                && NewInspection.HouseNumber != null && NewInspection.PostalCode != null
                && NewInspection.Country != null && NewInspection.City != null
                && NewInspection.Municipality != null)
                return true;

            return false;
        }

        public void AddInspection()
        {
            if (CanAddInspection())
            {
                try
                {

                    using (var inspectionRepository = InspectionList.InspectionRepositoryFactory.CreateRepository())
                    {
                        inspectionRepository.Add(NewInspection.toModel());
                    }

                    InspectionList.InspectionVMList.Add(NewInspection);
                    _navigationService.GoBack();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            MessageBox.Show("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Er is iets fout gegaan met het toevoegen van een inspectie!");
                }
                return;
            }

            MessageBox.Show("Niet alle verplichte velden zijn ingevoerd");
        }
    }
}
