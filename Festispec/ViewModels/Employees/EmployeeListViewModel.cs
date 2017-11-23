using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.Factory.Interface;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using Festispec.NavigationService;

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
        }

        public ICommand NavigateToEmployeeAddCommand { get; set; }
        public ICommand NavigateToEmployeeUpdateCommand { get; set; }
        public ICommand EmployeeDeleteCommand { get; set; }
        public ICommand SearchCommand { get; set; }

        public ObservableCollection<EmployeeViewModel> Employees { get; private set; }

        public EmployeeViewModel SelectedEmployee { get; set; }

        public string SearchUsername { get; set; } = "";
        public string SearchEmail { get; set; } = "";

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
            SearchCommand = new RelayCommand(LoadEmployees);
        }

        private void LoadEmployees()
        {
            DateTime today = DateTime.Today;
            using (var EmployeeRepository = _employeeRepositoryFactory.CreateRepository())
            {
                Employees =
                    new ObservableCollection<EmployeeViewModel>(
                        EmployeeRepository.Get()
                            .Where(Employee =>
                                (Employee.HiredTo.HasValue ? Employee.HiredTo.Value > today : true)
                                && Employee.Username.Contains(SearchUsername)
                                && Employee.Email.Contains(SearchEmail)
                                && !Employee.Role_Role.Equals("Inspecteur"))
                            .ToList()
                            .Select(Employee => _employeeViewModelFactory.CreateViewModel(Employee)));
                RaisePropertyChanged(nameof(Employees));
            }
        }
    }
}