using Festispec.Domain;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festispec.ViewModels.Employees
{
    public class EmployeeViewModel : ViewModelBase
    {
        // getters and setters
        public string Name
        {
            get
            {
                return _Employee.Name;
            }
            set
            {
                _Employee.Name = value;
                RaisePropertyChanged("Name");
            }
        }

        public string Website
        {
            get
            {
                return _Employee.Website;
            }
            set
            {
                _Employee.Website = value;
                RaisePropertyChanged("Website");
            }
        }

        public DateTime StartDate
        {
            get
            {
                return _Employee.Start;
            }
            set
            {
                _Employee.Start = value;
                RaisePropertyChanged("StartDate");
            }
        }

        public DateTime EndDate
        {
            get
            {
                return _Employee.End;
            }
            set
            {
                _Employee.End = value;
                RaisePropertyChanged("EndDate");
            }
        }

        // field
        private Employee _Employee;

        // constructors

        public EmployeeViewModel()
        {
            _Employee = new Employee();
        }

        public EmployeeViewModel(Employee i)
        {
            _Employee = i;
        }

        public Employee toModel()
        {
            return _Employee;
        }
    }
}
