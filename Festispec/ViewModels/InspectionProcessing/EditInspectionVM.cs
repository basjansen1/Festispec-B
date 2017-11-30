using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using Festispec.NavigationService;
using Festispec.ViewModels.InspectionProcessing;
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

        public InspectionListVM InspectionList { get; set; }
        public Customer Customer { get; set; }

        private INavigationService _navigationService;

        public EditInspectionVM(InspectionListVM inspectionList, INavigationService navigationService)
        {
            InspectionList = inspectionList;
            _navigationService = navigationService;
            Customer = inspectionList.SelectedInspection.Customer;
        }

        public bool CanEditInspection()
        {
            if (InspectionList.SelectedInspection.Name != null && InspectionList. SelectedInspection.StartDate != null
                 && InspectionList.SelectedInspection.EndDate != null)
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
                    inspectionRepository.Update(inspection);
                }
            }
            else
                MessageBox.Show("Er is iets fout gegaan met het bewerken van een inspectie");
        }
    }
}
