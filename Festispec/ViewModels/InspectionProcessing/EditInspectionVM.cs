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
        IGeoRepository _geoRepository;

        #region commands
        public ICommand EditInspectionCommand { get; set; }
        public ICommand CancelInspectionCommand { get; set; }
        public ICommand ShowRegulationCommand { get; set; }
        public ICommand SearchAddressCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        #endregion

        #region properties
        public InspectionListVM InspectionList { get; set; }
        public List<string> InspectionStatusList { get; set; }
        public string SelectedInspection { get; set; }
        #endregion

        #region fields
        private INavigationService _navigationService;
        private string _selectedMunicipality;
        #endregion

        #region constructor and methods
        public EditInspectionVM(InspectionListVM inspectionList, INavigationService navigationService, IGeoRepository geoRepository)
        {
            InspectionList = inspectionList;
            _navigationService = navigationService;
            _geoRepository = geoRepository;
            _selectedMunicipality = inspectionList.SelectedInspection.Municipality;

            EditInspectionCommand = new RelayCommand(SaveChanges);
            CancelInspectionCommand = new RelayCommand(_navigationService.GoBack);
            ShowRegulationCommand = new RelayCommand(OpenRegulation);
            SearchAddressCommand = new RelayCommand(()=>SearchAddress());
            DeleteCommand = new RelayCommand(DeleteSelectedInspection);

            InspectionStatusList = new List<string>();
            InspectionStatusList.Add("Geaccepteerd");
            InspectionStatusList.Add("Afgewezen");
            InspectionStatusList.Add("In afwachting");
        }

        public bool CanEditInspection()
        {
            if (InspectionList.SelectedInspection.Name != "" && InspectionList.SelectedInspection.StartDate != null
                && InspectionList.SelectedInspection.EndDate != null && InspectionList.SelectedInspection.Website != ""
                && InspectionList.SelectedInspection.Status != "" && InspectionList.SelectedInspection.Street != ""
                && InspectionList.SelectedInspection.HouseNumber != "" && InspectionList.SelectedInspection.PostalCode != ""
                && InspectionList.SelectedInspection.Country != "" && InspectionList.SelectedInspection.City != ""
                && InspectionList.SelectedInspection.Municipality != ""
                && InspectionList.SelectedInspection.StartDate <= InspectionList.SelectedInspection.EndDate)
            {
                if (InspectionList.SelectedInspection.PostalCode.Length < 6)
                {
                    MessageBox.Show("Postcode moet zes karakters bevatten");
                    return false;
                }
                return true;
            }

            return false;
        }

        public void SaveChanges()
        {
            if (CanEditInspection())
            {
                //InspectionList.SelectedInspection.Status = new InspectionStatus() { Status = SelectedInspection };
                if (!SearchAddress())
                {
                    return;
                }
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

        private void OpenRegulation()
        {
            _navigationService.NavigateTo(Routes.Routes.ShowRegulation, _selectedMunicipality);
        }

        private bool SearchAddress()
        {
            using (_geoRepository)
            {
                try
                {
                    var address = _geoRepository.Find(InspectionList.SelectedInspection.PostalCode,
                        InspectionList.SelectedInspection.HouseNumber);

                    InspectionList.SelectedInspection.Street = address.Street;
                    InspectionList.SelectedInspection.City = address.City;
                    InspectionList.SelectedInspection.Municipality = address.Municipality;
                    InspectionList.SelectedInspection.Country = address.Country;
                    InspectionList.SelectedInspection.Lat = address.Lat;
                    InspectionList.SelectedInspection.Long = address.Long;
                    InspectionList.SelectedInspection.Location = address.Location;

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
                                $"Geen adres gevonden op {InspectionList.SelectedInspection.PostalCode} {InspectionList.SelectedInspection.HouseNumber}");
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
        
        private void DeleteSelectedInspection()
        {
            InspectionList.DeleteSelectedInspection();

            _navigationService.GoBack();
        }
        #endregion
    }
}
