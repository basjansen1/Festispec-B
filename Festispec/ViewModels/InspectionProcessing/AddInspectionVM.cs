using Festispec.Domain;
using Festispec.ViewModels.InspectionProcessing;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Festispec.ViewModels.RequestProcessing
{
    public class AddInspectionVM : ViewModelBase
    {
        // getters and setters
        public InspectionListVM InspectionList { get; set; }
        public InspectionVM NewInspection { get; set; }
        public CustomerVM NewCustomer { get; set; }

        // commands
        public ICommand AddInspectionCommand { get; set; }

        // fields

        // constructor
        public AddInspectionVM(InspectionListVM InspectionList)
        {

        }

        // methods
        public bool CanAddInspection()
        {
            if (NewInspection.Name != null && NewInspection.StartDate != null
                && NewInspection.EndDate != null)
                return true;

            return false;
        }

        public void AddInspection()
        {
            if (CanAddInspection())
            {
                using (var inspectionRepository = InspectionList.InspectionRepositoryFactory.CreateRepository())
                {
                    inspectionRepository.Add(NewInspection.toModel());
                }

                InspectionList.InspectionVMList.Add(NewInspection);

                return;
            }

            Console.WriteLine("Can't add inspection!");
        }
    }
}
