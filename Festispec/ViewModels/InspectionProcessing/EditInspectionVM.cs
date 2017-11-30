using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using Festispec.NavigationService;
using GalaSoft.MvvmLight;
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
        public ICommand EditInspectionCommand { get; set; }

        private InspectionListVM _inspectionList { get; set; }
        private INavigationService _navigationService;

        public EditInspectionVM(InspectionListVM inspectionList, INavigationService navigationService)
        {
            _inspectionList = inspectionList;
            _navigationService = navigationService;
        }

        public bool CanEditInspection()
        {
            if (_inspectionList.SelectedInspection.Name != null && _inspectionList. SelectedInspection.StartDate != null
                 && _inspectionList.SelectedInspection.EndDate != null)
                return true;

            return false;
        }

        public void SaveChanges()
        {
            if (CanEditInspection())
            {
                using (var inspectionRepository = _inspectionList.InspectionRepositoryFactory.CreateRepository())
                {
                    Inspection inspection = _inspectionList.SelectedInspection.toModel();
                    inspectionRepository.Update(inspection);
                }
            }
            else
                MessageBox.Show("Er is iets fout gegaan met het bewerken van een inspectie");
        }
    }
}
