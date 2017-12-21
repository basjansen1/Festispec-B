using System.Windows.Input;
using Festispec.NavigationService;
using GalaSoft.MvvmLight.CommandWpf;
using Festispec.OfflineSync;
using System;
using Festispec.State;
using System.ComponentModel;
using System.Windows;

namespace Festispec.ViewModels
{
    public class MainViewModel : NavigatableViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IState _state;
        public string Title { get; set; }
        public MainViewModel(INavigationService navigationService, IState state) : base(navigationService)
        {   
            _navigationService = navigationService;
            _state = state;
            RegisterCommands();
            setTitle();
        }

        public void setTitle()
        {
            Title = "Festispec: Wij zetten de puntjes op de i ";
            if (!_state.IsOnline)
            {
                Title += ": OFFLINE";
            }
        }

        public ICommand OnWindowClosingCommand { get; private set; }
        public ICommand NavigateToTemplateListCommand { get; private set; }
        public ICommand NavigateToEmployeeListCommand { get; private set; }

        public ICommand NavigateToInspectorListCommand { get; private set; }
        public ICommand NavigateToInspectionListCommand { get; private set; }
        public ICommand NavigateToRegulationListCommand { get; private set; }

        public ICommand NavigateToReportCommand { get; private set; }

        public ICommand NavigateToCustomerListCommand { get; private set; }

        public void RegisterCommands()
        {
            OnWindowClosingCommand = new RelayCommand(OnWindowClosing);

            NavigateToTemplateListCommand =
                new RelayCommand(() => NavigationService.NavigateTo(Routes.Routes.TemplateList), () => _navigationService.CanAndHasAccess(Routes.Routes.TemplateList));
            NavigateToEmployeeListCommand = 
                new RelayCommand(() => NavigationService.NavigateTo(Routes.Routes.EmployeeList), () => _navigationService.CanAndHasAccess(Routes.Routes.EmployeeList));
            NavigateToInspectorListCommand = 
                new RelayCommand(() => NavigationService.NavigateTo(Routes.Routes.InspectorList), () => _navigationService.HasAccess(Routes.Routes.InspectorList));
            NavigateToInspectionListCommand =
                new RelayCommand(() => NavigationService.NavigateTo(Routes.Routes.InspectionList), () => _navigationService.HasAccess(Routes.Routes.InspectionList));
            NavigateToCustomerListCommand =  
                new RelayCommand(() => NavigationService.NavigateTo(Routes.Routes.CustomerList), () => _navigationService.CanAndHasAccess(Routes.Routes.CustomerList));
            NavigateToRegulationListCommand =
                new RelayCommand(() => NavigationService.NavigateTo(Routes.Routes.RegulationList), () => _navigationService.CanAndHasAccess(Routes.Routes.RegulationList));
            NavigateToReportCommand =
                new RelayCommand(() => NavigationService.NavigateTo(Routes.Routes.Reports), () => _navigationService.CanAndHasAccess(Routes.Routes.Reports));

        }

        private void OnWindowClosing()
        {
            if (_state.IsOnline)
            {
                // Sync data to offline
                (new OfflineSync.OfflineSync()).Sync();
            }
        }
    }
}