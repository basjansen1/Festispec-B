using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.Factory.Interface;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using Festispec.NavigationService;
using Festispec.ViewModels.Customer;

namespace Festispec.ViewModels.Employee
{
    public class EmployeeListViewModel : NavigatableViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IEmployeeRepositoryFactory _employeeRepositoryFactory;
        private readonly IEmployeeViewModelFactory _employeeViewModelFactory;

        public EmployeeListViewModel(INavigationService navigationService,
            IEmployeeRepositoryFactory employeeRepositoryFactory,
            IEmployeeViewModelFactory employeeViewModelFactory) : base(navigationService)
        {
            _navigationService = navigationService;
            _employeeRepositoryFactory = employeeRepositoryFactory;
            _employeeViewModelFactory = employeeViewModelFactory;

            RegisterCommands();
            LoadEmployees();

            NavigationService.PropertyChanged += OnNavigationServicePropertyChanged;
            EmployeeList = new List<EmployeeViewModel>();
        }

        public ICommand NavigateToEmployeeAddCommand { get; set; }
        public ICommand NavigateToEmployeeUpdateCommand { get; set; }
        public ICommand EmployeeDeleteCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand DeleteFilterCommand { get; set; }
        public ObservableCollection<EmployeeViewModel> Employees { get; private set; }

        public EmployeeViewModel SelectedEmployee { get; set; }

        public List<EmployeeViewModel> EmployeeList;
        public string SearchInput
        {
            get
            {
                return _searchInput;
            }
            set
            {
                _searchInput = value;
                RaisePropertyChanged("SearchInput");
            }
        }

        private string _searchInput;

        private void OnNavigationServicePropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "CurrentRoute") return;

            if (NavigationService.CurrentRoute != Routes.Routes.EmployeeList) return;

            LoadEmployees();
        }

        private void RegisterCommands()
        {
            NavigateToEmployeeAddCommand =
                new RelayCommand(() => _navigationService.NavigateTo(Routes.Routes.EmployeeAddOrUpdate));
            NavigateToEmployeeUpdateCommand = new RelayCommand(
                () => _navigationService.NavigateTo(Routes.Routes.EmployeeAddOrUpdate, SelectedEmployee),
                () => SelectedEmployee != null);
            EmployeeDeleteCommand = new RelayCommand(() => {
                SelectedEmployee.Delete();
                LoadEmployees();
                }, () => SelectedEmployee != null);
            SearchCommand = new RelayCommand(SearchEmployees);
            DeleteFilterCommand = new RelayCommand(DeleteFilter);
        }

        public void SearchEmployees()
        {
            if (SearchInput == null) return;

            LoadEmployees();
            EmployeeList.Clear();
            Employees.ToList().ForEach(n => EmployeeList.Add(n));
            Employees.Clear();

            foreach (var i in EmployeeList)
            {
                if (i.Username.ToLower().Contains(SearchInput.ToLower()) ||
                    i.Email.ToLower().Contains(SearchInput.ToLower()) ||
                    i.Role_Role.ToLower().Contains(SearchInput.ToLower()) ||
                    (i.Manager != null && i.Manager.Username.ToLower().Contains(SearchInput.ToLower())))
                {
                    Employees.Add(i);
                }
            }
        }

        public void LoadEmployees()
        {
            DateTime today = DateTime.Today;
            using (var employeeRepository = _employeeRepositoryFactory.CreateRepository())
            {
                Employees =
                    new ObservableCollection<EmployeeViewModel>(
                        employeeRepository.Get()
                            .Where(employee =>
                                (employee.HiredTo.HasValue ? employee.HiredTo.Value > today : true)
                                && !employee.Role_Role.Equals("Inspecteur"))
                            .ToList()
                            .Select(employee => _employeeViewModelFactory.CreateViewModel(employee)));
                RaisePropertyChanged(nameof(Employees));
            }
        }
        private void DeleteFilter()
        {
            LoadEmployees();
            SearchInput = null;
        }
    }
}