using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Festispec.ViewModels.RequestProcessing
{
    public class ProcessInspectionVM // this VM is intented for approving or rejecting an inspection request
    {
        // getters and setters
        public InspectionVM InspectionVM { get; set; }

        // commands
        public ICommand ApproveInspectionCommand { get; set; }
        public ICommand RejectInspectionCommand { get; set; }

        // fields

        // constructor
        public ProcessInspectionVM(InspectionVM InspectionVM)
        {

        }

        // methods
        public void ApproveInspection()
        {

        }

        public void RejectInspection()
        {

        }
    }
}
