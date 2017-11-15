using System.ComponentModel;

namespace Festispec.ViewModels.NavigationService
{
    public interface INavigationService : GalaSoft.MvvmLight.Views.INavigationService
    {
        object Parameter { get; }

        void GoBack(object parameter);

        event PropertyChangedEventHandler PropertyChanged;
    }
}