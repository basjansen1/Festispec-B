using Festispec.Domain;
using Festispec.Domain.Repository.Interface;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Festispec.ViewModels.RequestProcessing
{
    public class EditInspectionVM : ViewModelBase
    {
        public InspectionListVM InspectionList { get; set; }
        public ICommand EditInspectionCommand { get; set; }

        private IRepository<Inspection> _inspectionRepository;

        public EditInspectionVM(InspectionVM InspectionVM)
        {
        }

        public bool CanEditInspection()
        {
            if (InspectionList.SelectedInspection.Name != null && InspectionList.SelectedInspection.StartDate != null
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
                    inspectionRepository.Add(InspectionList.SelectedInspection.toModel());
                }
            }
            else
                MessageBox.Show("Er is iets fout gegaan met het bewerken van een inspectie");
        }
    }
}
