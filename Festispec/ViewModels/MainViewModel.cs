using System.Windows.Input;
using Festispec.NavigationService;
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

        public void RegisterCommands()
        {
            NavigateToTemplateListCommand =
                new RelayCommand(() => NavigationService.NavigateTo(Routes.Routes.TemplateList));
            NavigateToEmployeeListCommand = 
                new RelayCommand(() => NavigationService.NavigateTo(Routes.Routes.EmployeeList));
            NavigateToInspectorListCommand = 
                new RelayCommand(() => NavigationService.NavigateTo(Routes.Routes.InspectorList));
        }
    }
}