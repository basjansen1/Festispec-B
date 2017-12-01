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
        public List<string> InspectionStatusList { get; set; }
        public string SelectedInspection { get; set; }
        #endregion

        #region fields
        private INavigationService _navigationService;
        #endregion

        #region constructor and methods
        public EditInspectionVM(InspectionListVM inspectionList, INavigationService navigationService)
        {
            InspectionList = inspectionList;
            _navigationService = navigationService;

            EditInspectionCommand = new RelayCommand(SaveChanges);
            CancelInspectionCommand = new RelayCommand(_navigationService.GoBack);

            InspectionStatusList = new List<string>();
            InspectionStatusList.Add("Accepted");
            InspectionStatusList.Add("Declined");
            InspectionStatusList.Add("Pending");
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
                return true;

            return false;
        }

        public void SaveChanges()
        {
            if (CanEditInspection())
            {
           //     InspectionList.SelectedInspection.Status = new InspectionStatus() { Status = SelectedInspection };
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
