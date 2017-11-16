using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Festispec.ViewModels.Employees
{
    // The view variables and view methods will be implemented when the views are created
    public class EmployeeListViewModel : ViewModelBase
    {
        // getters and setters
        public ObservableCollection<EmployeeViewModel> EmployeeViewModelList { get; set; }
        public EmployeeViewModel SelectedEmployee
        {
            get
            {
                return _selectedEmployee;
            }
            set
            {
                _selectedEmployee = value;
                RaisePropertyChanged("SelectedEmployee");
            }
        }

        public IEmployeeRepositoryFactory EmployeeRepositoryFactory;

        // Commands
        public ICommand ShowAddEmployeeWindowCommand;
        public ICommand ShowEditEmployeeWindowCommand;
        public ICommand ShowProcessEmployeeWindowCommand;
        public ICommand DeleteEmployeeCommand;
        public ICommand FilterEmployeeViewModelListCommand;

        // fields
        private EmployeeViewModel _selectedEmployee;
        private string _selectedFilterOption;

        // constructor
        public EmployeeListViewModel(IEmployeeRepositoryFactory EmployeeRepositoryFactory)
        {
            List<EmployeeViewModel> EmployeeList;
            EmployeeRepositoryFactory = EmployeeRepositoryFactory;

            // instantiate commands 
            ShowAddEmployeeWindowCommand = new RelayCommand(ShowAddEmployeeWindow);
            ShowEditEmployeeWindowCommand = new RelayCommand(ShowEditEmployeeWindow);
            ShowProcessEmployeeWindowCommand = new RelayCommand(ShowProcessEmployeeWindow);
            DeleteEmployeeCommand = new RelayCommand(DeleteSelectedEmployee);

            using (var EmployeeRepository = EmployeeRepositoryFactory.CreateRepository())
            {
                EmployeeList = EmployeeRepository.Get().Select(i => new EmployeeViewModel(i)).ToList();
            }

            EmployeeViewModelList = new ObservableCollection<EmployeeViewModel>(EmployeeList);
        }

        // methods
        public void ShowAddEmployeeWindow()
        {

        }

        public void HideAddEmployeeWindow()
        {

        }

        public void ShowEditEmployeeWindow()
        {

        }

        public void ShowProcessEmployeeWindow()
        {

        }

        public void DeleteSelectedEmployee()
        {
            using (var EmployeeRepository = EmployeeRepositoryFactory.CreateRepository())
            {
                EmployeeRepository.Delete(SelectedEmployee.toModel());
            }
            this.EmployeeViewModelList.Remove(SelectedEmployee);
        }
    }
}
