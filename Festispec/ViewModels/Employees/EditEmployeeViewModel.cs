using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Festispec.ViewModels.Employees
{
    public class EditEmployeeViewModel : ViewModelBase
    {
        // getters and setters
        public EmployeeViewModel EmployeeViewModel { get; set; }

        // commands
        public ICommand EditEmployeeCommand { get; set; }

        // fields

        // constructors
        public EditEmployeeViewModel(EmployeeViewModel EmployeeViewModel)
        {

        }

        // methods
        public bool CanEditEmployee()
        {
            if (EmployeeViewModel.Name != null && EmployeeViewModel.StartDate != null
                 && EmployeeViewModel.EndDate != null)
                return true;

            return false;
        }

        public void SaveChanges()
        {
            if (CanEditEmployee())
            {

            }
        }
    }
}
