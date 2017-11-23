using System.ComponentModel;
using Festispec.Routes;

namespace Festispec.NavigationService
{
    public interface INavigationService
    {
        object Parameter { get; }

        Route CurrentRoute { get; }

        void GoBack();

        void GoBack(object parameter);

        void NavigateTo(Route route);

        void NavigateTo(Route route, object parameter);

        event PropertyChangedEventHandler PropertyChanged;

        void Configure(Route route);

        bool HasAccess(Route route);
    }
}