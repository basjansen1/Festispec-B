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
using Festispec.Domain.Repository.Interface;

namespace Festispec.ViewModels.Employees
{
    public class AddInspectionVM : ViewModelBase
    {
        IGeoRepository _geoRepository;
        public ICommand SearchAddressCommand { get; set; }
        #region fields
        private int _selectedIndexCustomerList;
        private DateTime _fromDate;
        private DateTime _toDate;
        private readonly INavigationService _navigationService;
        #endregion

        #region properties
        public InspectionListVM InspectionList { get; set; }
        public InspectionVM NewInspection { get; set; }
        public List<CustomerVM> CustomerList { get; set; }
        public List<string> CustomerNames { get; set; }
        public ICommand AddInspectionCommand { get; set; }
        public ICommand CloseWindowCommand { get; set; }

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

        public DateTime FromDate
        {
            get
            {
                return _fromDate;
            }
            set
            {
                _fromDate = value;
                NewInspection.StartDate = _fromDate.Date;
                RaisePropertyChanged();
            }
        }

        public DateTime ToDate
        {
            get
            {
                return _toDate;
            }
            set
            {
                _toDate = value;
                NewInspection.EndDate = _toDate.Date;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region constructor and methods
        public AddInspectionVM(InspectionListVM inspectionList, ICustomerRepositoryFactory customerRepositoryFactory, INavigationService navigationService, IGeoRepository GeoRepository)
        {
            InspectionList = inspectionList;
            _navigationService = navigationService;
            NewInspection = new InspectionVM();
            NewInspection.Status = "In afwachting";
            _geoRepository = GeoRepository;

            NewInspection.Location = DbGeography.PointFromText("POINT(50 5)", 4326);
            CustomerList = new List<CustomerVM>();
            CustomerNames = new List<string>();

            AddInspectionCommand = new RelayCommand(AddInspection);
            CloseWindowCommand = new RelayCommand(_navigationService.GoBack);
            SearchAddressCommand = new RelayCommand(() => SearchAddress());

            using (var customerRepository = customerRepositoryFactory.CreateRepository())
            {
                customerRepository.Get().ToList().ForEach(c => CustomerList.Add(new CustomerVM(c)));
            }

            CustomerList.ForEach(c => CustomerNames.Add(c.Name));

            if (CustomerList.Any())
                NewInspection.Customer = CustomerList.ElementAt(0).ToModel();

            _fromDate = DateTime.Now;
            _toDate = DateTime.Now;
        }

        public bool CanAddInspection()
        {
            if (NewInspection.Name != null && NewInspection.StartDate != null
                && NewInspection.EndDate != null && NewInspection.Website != null
                && NewInspection.Status != null && NewInspection.Street != null
                && NewInspection.HouseNumber != null && NewInspection.PostalCode != null
                && NewInspection.Country != null && NewInspection.City != null
                && NewInspection.Municipality != null)
            {
                if (DateTime.Compare(NewInspection.StartDate, NewInspection.EndDate) > 0)
                {
                    MessageBox.Show("Een inspectie kan niet eindigen voordat deze begonnen is");
                    return false;
                }

                return true;
            }

            MessageBox.Show("Niet alle verplichte velden zijn ingevoerd");

            return false;
        }

        public void AddInspection()
        {
            if (CanAddInspection())
            {
                if (!SearchAddress())
                {
                    return;
                }
                using (var inspectionRepository = InspectionList.InspectionRepositoryFactory.CreateRepository())
                {
                    inspectionRepository.Add(NewInspection.toModel());
                }

                InspectionList.InspectionVMList.Add(NewInspection);
                InspectionList.ReloadInspectionVMList();
                _navigationService.GoBack();
            }
        }
        private bool SearchAddress()
        {
            using (_geoRepository)
            {
                try
                {
                    var address = _geoRepository.Find(NewInspection.PostalCode,
                        NewInspection.HouseNumber);

                    NewInspection.Street = address.Street;
                    NewInspection.City = address.City;
                    NewInspection.Municipality = address.Municipality;
                    NewInspection.Country = address.Country;
                    NewInspection.Lat = address.Lat;
                    NewInspection.Long = address.Long;
                    NewInspection.Location = address.Location;

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
                                $"Geen adres gevonden op {NewInspection.PostalCode} {NewInspection.HouseNumber}");
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
        #endregion
    }
}
