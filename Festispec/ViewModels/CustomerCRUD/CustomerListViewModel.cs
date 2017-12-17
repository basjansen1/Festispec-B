using Festispec.Domain;
using Festispec.Domain.Repository.Factory;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.NavigationService;
using Festispec.ViewModels.Customer;
using Festispec.ViewModels.Factory.Interface;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Festispec.ViewModels.CustomerCRUD
{
    public class CustomerListViewModel : NavigatableViewModelBase
    {

        private readonly INavigationService _navigationService;
        private readonly ICustomerRepositoryFactory _CustomerRepositoryFactory;
        private readonly ICustomerViewModelFactory _CustomerViewModelFactory;
        public ObservableCollection<CustomerViewModel> CustomerVMList { get; set; }
        public string SearchInput
        {
            get { return _searchInput; }
            set { _searchInput = value;
                RaisePropertyChanged("SearchInput");
            }
        }
        private string _searchInput;
        private CustomerViewModel _selectedCustomer;
        private List<CustomerViewModel> _customerList;
        //private readonly INavigationService _navigationService;

        public CustomerListViewModel(INavigationService navigationService,
            ICustomerRepositoryFactory CustomerRepositoryFactory,
            ICustomerViewModelFactory CustomerViewModelFactory) : base(navigationService)
        {
            RegisterCommands();

            _customerList = new List<CustomerViewModel>();

            _navigationService = navigationService;
            _CustomerRepositoryFactory = CustomerRepositoryFactory;
            _CustomerViewModelFactory = CustomerViewModelFactory;

            LoadCustomers();

            NavigationService.PropertyChanged += OnNavigationServicePropertyChanged;

            SearchItems = new ObservableCollection<string>();
            SearchItems.Add("Naam");
            SearchItems.Add("Gemeente");
            SearchItems.Add("Voornaam contact");
            SearchItems.Add("Achternaam contact");
            SearchItems.Add("Email");

            // instantiate views   
            using (var customerRepository = CustomerRepositoryFactory.CreateRepository())
            {
                CustomerVMList = new ObservableCollection<CustomerViewModel>(customerRepository.Get().ToList().Select(i => new CustomerViewModel(i)));
            }
        }

        public ICommand NavigateToCustomerAddCommand { get; set; }
        public ICommand NavigateToCustomerUpdateCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand DeleteSearchCommand { get; set; }
        public ICommand SelectedSearch { get; set; }


        public ObservableCollection<CustomerViewModel> Customers { get; private set; }

        public CustomerViewModel SelectedCustomer { get; set; }

        public string SearchName { get; set; } = "";

        public string SelectedSearchOption { get; set; } = "";

        public ObservableCollection<String> SearchItems {get; set;}

        private void OnNavigationServicePropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != nameof(NavigationService.CurrentRoute)) return;

            if (NavigationService.CurrentRoute != Routes.Routes.CustomerList) return;
        }

        //register ICommands
        private void RegisterCommands()
        {
            NavigateToCustomerAddCommand =
                new RelayCommand(() => _navigationService.NavigateTo(Routes.Routes.CustomerAddOrUpdate));

            SearchCommand = new RelayCommand(Search);
            DeleteSearchCommand = new RelayCommand(DeleteFilter);

            NavigateToCustomerUpdateCommand = new RelayCommand(
                () => _navigationService.NavigateTo(Routes.Routes.CustomerAddOrUpdate, SelectedCustomer),
                () => SelectedCustomer != null
                );
        }

        private void Search()
        {
            if (SearchInput != null)
            {
                ReloadCustomerVMList();
                _customerList.Clear();
                CustomerVMList.ToList().ForEach(n => _customerList.Add(n));
                CustomerVMList.Clear();

                foreach (CustomerViewModel i in _customerList)
                {
                    if (i.Name.ToLower().Contains(SearchInput.ToLower()) || i.Name.ToLower().Contains(SearchInput.ToLower()) ||
                        i.City.ToLower().Contains(SearchInput.ToLower()) || i.Municipality.ToLower().Contains(SearchInput.ToLower()))
                    {
                        CustomerVMList.Add(i);
                    }
                }
            }
        }
        public void ReloadCustomerVMList()
        {
            using (var customerRepository = CustomerRepositoryFactory.CreateRepository())
            {
                CustomerVMList.Clear();
                customerRepository.Get().ToList().ForEach(i => CustomerVMList.Add(new CustomerViewModel(i)));
            }
        }
        private void DeleteFilter()
        {
            ReloadCustomerVMList();
            SearchInput = null;
        }


        //Loads in the customers from the database, is called when something changes
        private void LoadCustomers()
        {
            DateTime today = DateTime.Today;
            using (var CustomerRepository = _CustomerRepositoryFactory.CreateRepository())
            {
                Customers =
                    new ObservableCollection<CustomerViewModel>(
                        CustomerRepository.Get()
                            .ToList()
                            .Select(Customer => _CustomerViewModelFactory.CreateViewModel(Customer)));
                RaisePropertyChanged(nameof(Customers));
            }
        }
    }
}
