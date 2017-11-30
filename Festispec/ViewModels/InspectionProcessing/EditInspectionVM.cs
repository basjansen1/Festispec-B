using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using Festispec.NavigationService;
using Festispec.ViewModels.InspectionProcessing;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Festispec.ViewModels.Employees
{
    public class EditInspectionVM : ViewModelBase
    {
        #region commands
        public ICommand EditInspectionCommand { get; set; }
        public ICommand CancelInspectionCommand { get; set; }
        #endregion

        #region properties
        public InspectionListVM InspectionList { get; set; }
        public List<CustomerVM> CustomerList { get; set; }
        public Customer Customer { get; set; }
        public List<string> CustomerNamesList { get; set; }

        public string Name
        {
            get
            {
                return Customer.Name;
            }
            set
            {
                Customer.Name = value;
                RaisePropertyChanged("CustomerName");
            }
        }

        public string Status
        {
            get
            {
                return InspectionList.SelectedInspection.Status;
            }
            set
            {
                InspectionList.SelectedInspection.Status = value;
                RaisePropertyChanged("Status");
            }
        }
        #endregion

        #region fields
        private INavigationService _navigationService;
        #endregion

        #region constructor and methods
        public EditInspectionVM(InspectionListVM inspectionList, INavigationService navigationService, ICustomerRepositoryFactory customerRepositoryFactory)
        {
            InspectionList = inspectionList;
            _navigationService = navigationService;
            Customer = inspectionList.SelectedInspection.Customer;
            CustomerList = new List<CustomerVM>();
            CustomerNamesList = new List<string>();

            EditInspectionCommand = new RelayCommand(SaveChanges);
            CancelInspectionCommand = new RelayCommand(_navigationService.GoBack);

            using (var customerRepository = customerRepositoryFactory.CreateRepository())
            {
                customerRepository.Get().ToList().ForEach(c => CustomerList.Add(new CustomerVM(c)));
            }

            CustomerList.ForEach(c => CustomerNamesList.Add(c.Name));
        }

        public bool CanEditInspection()
        {
            if (InspectionList.SelectedInspection.Name != null && InspectionList.SelectedInspection.StartDate != null
                && InspectionList.SelectedInspection.EndDate != null && InspectionList.SelectedInspection.Website != null
                && InspectionList.SelectedInspection.Status != null && InspectionList.SelectedInspection.Street != null
                && InspectionList.SelectedInspection.HouseNumber != null && InspectionList.SelectedInspection.PostalCode != null
                && InspectionList.SelectedInspection.Country != null && InspectionList.SelectedInspection.City != null
                && InspectionList.SelectedInspection.Municipality != null)
                return true;

            return false;
        }

        public void SaveChanges()
        {
            if (CanEditInspection())
            {
                using (var inspectionRepository = InspectionList.InspectionRepositoryFactory.CreateRepository())
                {
                    Inspection inspection = InspectionList.SelectedInspection.toModel();
                    inspectionRepository.AddOrUpdate(inspection);
                }
                _navigationService.GoBack();
            }
            else
                MessageBox.Show("Er is iets fout gegaan met het bewerken van een inspectie! Vul alle velden in");
        }
        #endregion
    }
}
