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
using Festispec.ViewModels.NavigationService;

namespace Festispec.ViewModels.Employees
{
    public class AddInspectionVM : ViewModelBase
    {
        public InspectionListVM InspectionList { get; set; }
        public InspectionVM NewInspection { get; set; }
        public CustomerVM NewCustomer { get; set; }
        public List<CustomerVM> CustomerList { get; set; }
        public List<string> CustomerNames { get; set; }
        private Dictionary<string, CustomerVM> CustomerDictionairy { get; set; }
        public CustomerVM SelectedCustomer
        {
            get
            {
                return _customer;
            }
            set
            {
                _customer = value;
                MessageBox.Show(_customer.Email);
                NewInspection.CustomerId = _customer.ID;
                RaisePropertyChanged("customer");
            }
        }
        public string SelectedCustomerName
        {
            get
            {
                return _customerName;
            }
            set
            {
                if (value != null)
                {
                    _customerName = value;
                    CustomerDictionairy.TryGetValue(value, out _customer);
                }
            }
        }
        public ICommand AddInspectionCommand { get; set; }
        public ICommand CloseWindowCommand { get; set; }
        private readonly INavigationService _navigationService;

        public AddInspectionVM(InspectionListVM inspectionList, ICustomerRepositoryFactory customerRepositoryFactory, INavigationService navigationService)
        {
            InspectionList = inspectionList;
            _navigationService = navigationService;
            NewInspection = new InspectionVM();
            NewInspection.StartDate = DateTime.Now;
            NewInspection.EndDate = DateTime.Now;
            NewInspection.Status = "Pending";
            NewInspection.CustomerId = 11;

            NewInspection.Location = DbGeography.PointFromText("POINT(50 5)", 4326);
            CustomerList = new List<CustomerVM>();
            CustomerNames = new List<string>();
            CustomerDictionairy = new Dictionary<string, CustomerVM>();
            AddInspectionCommand = new RelayCommand(AddInspection);
            CloseWindowCommand = new RelayCommand(_navigationService.GoBack); 

            using(var customerRepository = customerRepositoryFactory.CreateRepository())
            {
                customerRepository.Get().ToList().ForEach(c => CustomerList.Add(new CustomerVM(c)));
            }
            CustomerList.ForEach(c => CustomerNames.Add(c.FullName));
            CustomerList.ForEach(c => CustomerDictionairy.Add(c.FullName, c));
        }

        private CustomerVM _customer;
        private string _customerName;

        public bool CanAddInspection()
        {
            if (NewInspection.Name != null && NewInspection.StartDate != null
                && NewInspection.EndDate != null && NewInspection.Website != null
                && NewInspection.Status != null && NewInspection.Street != null
                && NewInspection.HouseNumber != null && NewInspection.PostalCode != null
                && NewInspection.Country != null && NewInspection.City != null
                && NewInspection.Municipality != null && _customer != null
                )
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
