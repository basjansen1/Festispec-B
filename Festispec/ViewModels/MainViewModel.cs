using System.Windows.Input;
using Festispec.NavigationService;
using GalaSoft.MvvmLight.CommandWpf;

namespace Festispec.ViewModels
{
    public class MainViewModel : NavigatableViewModelBase
    {
        private readonly INavigationService _navigationService;
        public MainViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            RegisterCommands();
        }

        public ICommand NavigateToTemplateListCommand { get; private set; }
        public ICommand NavigateToEmployeeListCommand { get; private set; }

        public ICommand NavigateToInspectorListCommand { get; private set; }

        public void RegisterCommands()
        {
            NavigateToTemplateListCommand =
                new RelayCommand(() => NavigationService.NavigateTo(Routes.Routes.TemplateList), () => _navigationService.HasAccess(Routes.Routes.TemplateList));
            NavigateToEmployeeListCommand = 
                new RelayCommand(() => NavigationService.NavigateTo(Routes.Routes.EmployeeList), () => _navigationService.HasAccess(Routes.Routes.EmployeeList));
            NavigateToInspectorListCommand = 
                new RelayCommand(() => NavigationService.NavigateTo(Routes.Routes.InspectorList), () => _navigationService.HasAccess(Routes.Routes.InspectorList));
        }
    }
}