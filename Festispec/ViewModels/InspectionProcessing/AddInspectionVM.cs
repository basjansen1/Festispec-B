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
            
        }

        public void AddInspection()
        {

        }
    }
}
