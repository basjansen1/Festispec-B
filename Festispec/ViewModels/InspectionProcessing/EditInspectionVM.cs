using Festispec.Domain;
using Festispec.Domain.Repository.Interface;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Festispec.ViewModels.RequestProcessing
{
    public class EditInspectionVM : ViewModelBase
    {
        // getters and setters
        public InspectionListVM InspectionList { get; set; }

        // commands
        public ICommand EditInspectionCommand { get; set; }

        // fields
        private IRepository<Inspection> _inspectionRepository;

        // constructors
        public EditInspectionVM(InspectionVM InspectionVM)
        {
        }

        // methods
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
        }
    }
}
