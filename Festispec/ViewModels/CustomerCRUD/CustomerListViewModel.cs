using Festispec.Domain;
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
using System.Windows;
using System.Windows.Input;

namespace Festispec.ViewModels.CustomerCRUD
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

            SearchItems = new ObservableCollection<string>();
            SearchItems.Add("Naam");
            SearchItems.Add("Gemeente");
            SearchItems.Add("Voornaam contact");
            SearchItems.Add("Achternaam contact");
            SearchItems.Add("Email");
        }

        public ICommand NavigateToCustomerAddCommand { get; set; }
        public ICommand NavigateToCustomerUpdateCommand { get; set; }
        public ICommand NavigateToReport { get; set; }

        public ICommand SelectedSearch { get; set; }


        public ObservableCollection<CustomerViewModel> Customers { get; private set; }

        public CustomerViewModel SelectedCustomer { get; set; }

        public string SearchName { get; set; } = "";

        public string SelectedSearchOption { get; set; } = "";

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

            NavigateToReport = 
                new RelayCommand(() => _navigationService.NavigateTo(Routes.Routes.GenerateReport), () => SelectedCustomer != null);

            NavigateToCustomerUpdateCommand = new RelayCommand(
                () => _navigationService.NavigateTo(Routes.Routes.CustomerAddOrUpdate, SelectedCustomer),
                () => SelectedCustomer != null
                );

            SelectedSearch = new RelayCommand(SearchCustomers);

        }

        private void SearchCustomers()
        {

            if (SearchName.Equals("")) //if searchbox is empty
            {
                LoadCustomers();
            }
            else
            {
                using (var CustomerRepository = _CustomerRepositoryFactory.CreateRepository())
                {
                    switch (SelectedSearchOption)
                    {
                        case "Naam":
                            Customers =
                        new ObservableCollection<CustomerViewModel>(
                            CustomerRepository.Get()
                                .Where(Customer =>
                                    Customer.Name.Contains(SearchName))
                                .ToList()
                                .Select(Customer => _CustomerViewModelFactory.CreateViewModel(Customer)));
                            RaisePropertyChanged(nameof(Customers));
                            break;
                        case "Gemeente":
                            Customers =
                                 new ObservableCollection<CustomerViewModel>(
                                CustomerRepository.Get()
                                .Where(Customer =>
                                 Customer.Municipality.Contains(SearchName))
                                 .ToList()
                                 .Select(Customer => _CustomerViewModelFactory.CreateViewModel(Customer)));
                            RaisePropertyChanged(nameof(Customers));
                            break;
                        case "Voornaam contact":
                            Customers =
                                new ObservableCollection<CustomerViewModel>(
                            CustomerRepository.Get()
                             .Where(Customer =>
                               Customer.FirstName.Contains(SearchName))
                                 .ToList()
                                 .Select(Customer => _CustomerViewModelFactory.CreateViewModel(Customer)));
                            RaisePropertyChanged(nameof(Customers));
                            break;
                        case "Achternaam contact":
                            Customers =
                            new ObservableCollection<CustomerViewModel>(
                            CustomerRepository.Get()
                                 .Where(Customer =>
                                    Customer.LastName.Contains(SearchName))
                            .ToList()
                             .Select(Customer => _CustomerViewModelFactory.CreateViewModel(Customer)));
                            RaisePropertyChanged(nameof(Customers));
                            break;
                        case "Email":
                            Customers =
                        new ObservableCollection<CustomerViewModel>(
                        CustomerRepository.Get()
                            .Where(Customer =>
                                 Customer.Email.Contains(SearchName))
                            .ToList()
                            .Select(Customer => _CustomerViewModelFactory.CreateViewModel(Customer)));
                            RaisePropertyChanged(nameof(Customers));
                            break;
                    }

                }
            }         
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
