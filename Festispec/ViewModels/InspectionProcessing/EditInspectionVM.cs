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
        public InspectionVM InspectionVM { get; set; }

        // commands
        public ICommand EditInspectionCommand { get; set; }

        // fields

        // constructors
        public EditInspectionVM(InspectionVM InspectionVM)
        {

        }

        // methods
        public bool CanEditInspection()
        {

        }

        public void SaveChanges()
        {

        }
    }
}
