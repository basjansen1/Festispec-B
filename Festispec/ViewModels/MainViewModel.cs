using System.Windows.Input;
using Festispec.ViewModels.NavigationService;
using GalaSoft.MvvmLight.CommandWpf;

namespace Festispec.ViewModels
{
    public class MainViewModel : NavigatableViewModelBase
    {
        public MainViewModel(INavigationService navigationService) : base(navigationService)
        {
            RegisterCommands();
        }

        public ICommand NavigateToTemplateListCommand { get; private set; }
        public ICommand NavigateToEmployeeListCommand { get; private set; }

        public ICommand NavigateToInspectorListCommand { get; private set; }
        public ICommand NavigateToInspectionListCommand { get; private set; }

        public void RegisterCommands()
        {
            NavigateToTemplateListCommand =
                new RelayCommand(() => NavigationService.NavigateTo(Routes.Routes.TemplateList.Key));
            NavigateToEmployeeListCommand =
                new RelayCommand(() => NavigationService.NavigateTo(Routes.Routes.EmployeeList.Key));
            NavigateToInspectorListCommand =
                new RelayCommand(() => NavigationService.NavigateTo(Routes.Routes.InspectorList.Key));
            NavigateToInspectionListCommand =
                new RelayCommand(() => NavigationService.NavigateTo(Routes.Routes.InspectionList.Key));
        }
    }
}