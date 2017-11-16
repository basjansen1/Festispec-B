using Festispec.Domain;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Festispec.ViewModels.Employees
{
    public class AddEmployeeViewModel : ViewModelBase
    {
        // getters and setters
        public EmployeeListViewModel EmployeeList { get; set; }
        public EmployeeViewModel NewEmployee { get; set; }

        // commands
        public ICommand AddEmployeeCommand { get; set; }

        // fields

        // constructor
        public AddEmployeeViewModel(EmployeeListViewModel EmployeeList)
        {

        }

        // methods
        public bool CanAddEmployee()
        {
            if (NewEmployee.Name != null && NewEmployee.StartDate != null
                && NewEmployee.EndDate != null)
                return true;

            return false;
        }

        public void AddEmployee()
        {
            if (CanAddEmployee())
            {
                using (var EmployeeRepository = EmployeeList.EmployeeRepositoryFactory.CreateRepository())
                {
                    EmployeeRepository.Add(NewEmployee.toModel());
                }

                EmployeeList.EmployeeViewModelList.Add(NewEmployee);

                return;
            }

            Console.WriteLine("Can't add Employee!");
        }
    }
}
