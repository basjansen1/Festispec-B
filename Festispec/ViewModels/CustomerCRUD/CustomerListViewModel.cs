using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.NavigationService;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Festispec.ViewModels.CustomerCRUD
{
    class CustomerListViewModel : NavigatableViewModelBase
    {

        private readonly INavigationService _navigationService;
        private readonly ICustomerRepositoryFactory _CustomerRepositoryFactory;
        private readonly ICustomerViewModelFactory _CustomerViewModelFactory;

        public CustomerListViewModel(INavigationService navigationService,
            ICustomerRepositoryFactory CustomerRepositoryFactory,
            ICustomerViewModelFactory CustomerViewModelFactory) : base(navigationService)
        {
            _navigationService = navigationService;
            _CustomerRepositoryFactory = CustomerRepositoryFactory;
            _CustomerViewModelFactory = CustomerViewModelFactory;

            RegisterCommands();
            LoadCustomers();

            NavigationService.PropertyChanged += OnNavigationServicePropertyChanged;
        }

        public ICommand NavigateToCustomerAddCommand { get; set; }
        public ICommand NavigateToCustomerUpdateCommand { get; set; }
        public ICommand CustomerDeleteCommand { get; set; }
        public ICommand SearchCommand { get; set; }

        public ObservableCollection<CustomerViewModel> Customers { get; private set; }

        public CustomerViewModel SelectedCustomer { get; set; }

        public string SearchUsername { get; set; } = "";
        public string SearchEmail { get; set; } = "";

        private void OnNavigationServicePropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "CurrentPageKey") return;

            if (NavigationService.CurrentPageKey != Routes.Routes.CustomerList.Key) return;

            LoadCustomers();
        }

        private void RegisterCommands()
        {
            NavigateToCustomerAddCommand =
                new RelayCommand(() => _navigationService.NavigateTo(Routes.Routes.CustomerAddOrUpdate.Key));
            NavigateToCustomerUpdateCommand = new RelayCommand(
                () => _navigationService.NavigateTo(Routes.Routes.CustomerAddOrUpdate.Key, SelectedCustomer),
                () => SelectedCustomer != null);
            CustomerDeleteCommand = new RelayCommand(() => {
                SelectedCustomer.Delete();
                LoadCustomers();
            }, () => SelectedCustomer != null);
            SearchCommand = new RelayCommand(LoadCustomers);
        }

        private void LoadCustomers()
        {
            DateTime today = DateTime.Today;
            using (var CustomerRepository = _CustomerRepositoryFactory.CreateRepository())
            {
                Customers =
                    new ObservableCollection<CustomerViewModel>(
                        CustomerRepository.Get()
                            .Where(Customer =>
                                (Customer.HiredTo.HasValue ? Customer.HiredTo.Value > today : true)
                                && Customer.Username.Contains(SearchUsername)
                                && Customer.Email.Contains(SearchEmail)
                                && !Customer.Role_Role.Equals("Inspecteur"))
                            .ToList()
                            .Select(Customer => _CustomerViewModelFactory.CreateViewModel(Customer)));
                RaisePropertyChanged(nameof(Customers));
            }
        }
    }
}
