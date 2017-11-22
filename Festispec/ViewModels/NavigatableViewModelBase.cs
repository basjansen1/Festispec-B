using Festispec.NavigationService;
using GalaSoft.MvvmLight;

namespace Festispec.ViewModels
{
    public abstract class NavigatableViewModelBase : ViewModelBase
    {
        protected readonly INavigationService NavigationService;

        protected NavigatableViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }
    }
}