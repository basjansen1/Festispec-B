using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.NavigationService;
using GalaSoft.MvvmLight.CommandWpf;

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

            //NavigationService.PropertyChanged += OnNavigationServicePropertyChanged;
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
            if (args.PropertyName != "CurrentPageKey") return;

            if (NavigationService.CurrentPageKey != Routes.Routes.EmployeeList.Key) return;

            UpdateEmployeesFromNavigationParameter();
        }

        private void UpdateEmployeesFromNavigationParameter()
        {
            var EmployeeViewModel = NavigationService.Parameter as EmployeeViewModel;
            if (EmployeeViewModel == null) return;

            var existing = Employees.SingleOrDefault(Employee => Employee.Id == EmployeeViewModel.Id);
            if (existing == null)
            {
                Employees.Add(EmployeeViewModel);
            }
            else
            {
                var index = Employees.IndexOf(existing);
                Employees.RemoveAt(index);
                Employees.Insert(index, EmployeeViewModel);
            }
        }

        private void RegisterCommands()
        {
            NavigateToEmployeeAddCommand =
                new RelayCommand(() => _navigationService.NavigateTo(Routes.Routes.EmployeeAddOrUpdate.Key));
            NavigateToEmployeeUpdateCommand = new RelayCommand(
                () => _navigationService.NavigateTo(Routes.Routes.EmployeeAddOrUpdate.Key, SelectedEmployee),
                () => SelectedEmployee != null);
            EmployeeDeleteCommand = new RelayCommand(() => SelectedEmployee.Delete(), () => SelectedEmployee != null);
            SearchCommand = new RelayCommand(LoadEmployees);
        }

        private void LoadEmployees()
        {
            using (var EmployeeRepository = _employeeRepositoryFactory.CreateRepository())
            {
                Employees =
                    new ObservableCollection<EmployeeViewModel>(
                        EmployeeRepository.Get()
                            .Where(Employee =>
                                Employee.Username.Contains(SearchUsername)
                                && Employee.Email.Contains(SearchEmail))
                            .ToList()
                            .Select(Employee => _employeeViewModelFactory.CreateViewModel(Employee)));
                RaisePropertyChanged(nameof(Employees));
            }
        }
    }
}