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

        public void RegisterCommands()
        {
            NavigateToTemplateListCommand =
                new RelayCommand(() => NavigationService.NavigateTo(Routes.Routes.TemplateList.Key));
        }
    }
}