using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Festispec.ViewModels.Employees
{
    class AddEmployee
    {
        public ICommand Add_Employee { get; set; }

        public AddEmployee()
        {
            RegisterCommands();
        }

        private void RegisterCommands()
        {
            Add_Employee = new RelayCommand();
        }
    }
}
