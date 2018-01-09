using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.NavigationService;
using Festispec.ViewModels.Factory.Interface;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Festispec.ViewModels.Customer
{
    public class CustomerListViewModel : NavigatableViewModelBase
    {

        private readonly INavigationService _navigationService;
        private readonly ICustomerRepositoryFactory _CustomerRepositoryFactory;
        private readonly ICustomerViewModelFactory _CustomerViewModelFactory;

        public CustomerListViewModel(INavigationService navigationService,
            ICustomerRepositoryFactory CustomerRepositoryFactory,
            ICustomerViewModelFactory CustomerViewModelFactory) : base(navigationService)
        {
            RegisterCommands();
           
            _navigationService = navigationService;
            _CustomerRepositoryFactory = CustomerRepositoryFactory;
            _CustomerViewModelFactory = CustomerViewModelFactory;

            LoadCustomers();

            NavigationService.PropertyChanged += OnNavigationServicePropertyChanged;
            _customerList = new List<CustomerViewModel>();
        }



        public ICommand NavigateToCustomerAddCommand { get; set; }
        public ICommand NavigateToCustomerUpdateCommand { get; set; }
        public ICommand NavigateToReport { get; set; }

        public ICommand SelectedSearch { get; set; }
        public ICommand DeleteFilterCommand { get; set; }
        private readonly List<CustomerViewModel> _customerList;
        public ObservableCollection<CustomerViewModel> Customers { get; private set; }
        public CustomerViewModel SelectedCustomer { get; set; }

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

        public ObservableCollection<String> SearchItems {get; set;}

        private void OnNavigationServicePropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            SearchCustomers();


            if (args.PropertyName != nameof(NavigationService.CurrentRoute)) return;

            if (NavigationService.CurrentRoute != Routes.Routes.CustomerList) return;
        }

        //register ICommands
        private void RegisterCommands()
        {
            NavigateToCustomerAddCommand =
                new RelayCommand(() => _navigationService.NavigateTo(Routes.Routes.CustomerAddOrUpdate));

            DeleteFilterCommand = new RelayCommand(DeleteFilter);

            NavigateToReport = new RelayCommand(
                () => _navigationService.NavigateTo(Routes.Routes.GenerateReport, SelectedCustomer), 
                () => SelectedCustomer != null);

            NavigateToCustomerUpdateCommand = new RelayCommand(
                () => _navigationService.NavigateTo(Routes.Routes.CustomerAddOrUpdate, SelectedCustomer),
                () => SelectedCustomer != null
                );

            SelectedSearch = new RelayCommand(SearchCustomers);

        }

        private void SearchCustomers()
        {
            if (SearchInput == null) return;
            LoadCustomers();
            _customerList.Clear();
            Customers.ToList().ForEach(n => _customerList.Add(n));
            Customers.Clear();

            foreach (var i in _customerList)
            {
                if (i.Name != null && i.Name.ToLower().Contains(SearchInput.ToLower()) ||
                    i.Email != null && i.Email.ToLower().Contains(SearchInput.ToLower()) ||
                    i.Municipality != null && i.Municipality.ToLower().Contains(SearchInput.ToLower()) ||
                    i.FirstName != null && i.FirstName.ToLower().Contains(SearchInput.ToLower()) ||
                    i.LastName != null && i.LastName.ToLower().Contains(SearchInput.ToLower()))
                {
                    Customers.Add(i);
                }
            }
        }         
        //Loads in the customers from the database, is called when something changes
        private void LoadCustomers()
        {
            DateTime today = DateTime.Today;
            using (var customerRepository = _CustomerRepositoryFactory.CreateRepository())
            {
                Customers =
                    new ObservableCollection<CustomerViewModel>(
                        customerRepository.Get()
                            .ToList()
                            .Select(customer => _CustomerViewModelFactory.CreateViewModel(customer)));
                RaisePropertyChanged(nameof(Customers));
            }
        }
        private void DeleteFilter()
        {
            LoadCustomers();
            SearchInput = null;
        }
    }
}
