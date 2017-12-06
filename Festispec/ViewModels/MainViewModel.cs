using System.Windows.Input;
using Festispec.NavigationService;
using GalaSoft.MvvmLight.CommandWpf;
using Festispec.OfflineSync;
using System;
using Festispec.State;

namespace Festispec.ViewModels
{
    public class MainViewModel : NavigatableViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IState _state;
        public MainViewModel(INavigationService navigationService, IState state) : base(navigationService)
        {
            _navigationService = navigationService;
            _state = state;
            RegisterCommands();
        }

        public ICommand OnWindowClosingCommand { get; private set; }
        public ICommand NavigateToTemplateListCommand { get; private set; }
        public ICommand NavigateToEmployeeListCommand { get; private set; }

        public ICommand NavigateToInspectorListCommand { get; private set; }
        public ICommand NavigateToInspectionListCommand { get; private set; }
        public ICommand NavigateToRegulationsListCommand { get; private set; }

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
                new RelayCommand(() => NavigationService.NavigateTo(Routes.Routes.InspectorList), () => _navigationService.CanAndHasAccess(Routes.Routes.InspectorList));
            NavigateToRegulationsListCommand =
                new RelayCommand(() => NavigationService.NavigateTo(Routes.Routes.RegulationsList), () => _navigationService.CanAndHasAccess(Routes.Routes.RegulationsList));
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