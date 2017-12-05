using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Festispec.Annotations;
using Festispec.Routes;
using Festispec.State;

namespace Festispec.NavigationService
{
    public class NavigationService : INavigationService, INotifyPropertyChanged
    {
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Fields

        private readonly Dictionary<string, Uri> _pagesByKey;
        private readonly List<Route> _historic;
        private Route _currentRoute;
        private readonly IState _state;

        #endregion

        #region Properties

        public Route CurrentRoute
        {
            get { return _currentRoute; }
            set
            {
                if (_currentRoute == value)
                    return;
                _currentRoute = value;
                OnPropertyChanged(nameof(CurrentRoute));
            }
        }

        public object Parameter { get; private set; }

        #endregion

        #region Ctors and Methods

        public NavigationService(IState state)
        {
            _state = state;
            _pagesByKey = new Dictionary<string, Uri>();
            _historic = new List<Route>();
        }

        public void GoBack()
        {
            GoBack(null);
        }

        public void GoBack(object parameter)
        {
            if (_historic.Count <= 1) return;

            _historic.RemoveAt(_historic.Count - 1);
            NavigateTo(_historic.Last(), parameter);
        }

        public void NavigateTo(Route route)
        {
            NavigateTo(route, null);
        }

        public virtual void NavigateTo(Route route, object parameter)
        {
            lock (_pagesByKey)
            {
                if (!_pagesByKey.ContainsKey(route.Key))
                    throw new ArgumentException($@"No such page: {route.Key} ", nameof(route.Key));

                if (!HasAccess(route))
                {
                    MessageBox.Show("Geen bevoegdheid om deze pagina te bezoeken");
                    return;
                }

                var frame = GetDescendantFromName(GetMainWindow(), "MainFrame") as Frame;

                if (frame != null)
                    frame.Source = _pagesByKey[route.Key];
                Parameter = parameter;
                if (_historic.Count == 0 || _historic.Last() != route) _historic.Add(route);
                CurrentRoute = route;
            }
        }

        public void Configure(Route route)
        {
            lock (_pagesByKey)
            {
                if (_pagesByKey.ContainsKey(route.Key))
                    _pagesByKey[route.Key] = route.PageType;
                else
                    _pagesByKey.Add(route.Key, route.PageType);
            }
        }

        public static MainWindow GetMainWindow()
        {
            return Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
        }

        private static FrameworkElement GetDescendantFromName(DependencyObject parent, string name)
        {
            var count = VisualTreeHelper.GetChildrenCount(parent);

            if (count < 1)
                return null;

            for (var i = 0; i < count; i++)
            {
                var frameworkElement = VisualTreeHelper.GetChild(parent, i) as FrameworkElement;

                if (frameworkElement == null) continue;

                if (frameworkElement.Name == name)
                    return frameworkElement;

                frameworkElement = GetDescendantFromName(frameworkElement, name);
                if (frameworkElement != null)
                    return frameworkElement;
            }
            return null;
        }

        public bool HasAccess(Route route)
        {
            if (route.Roles == null) return true;
            return route.Roles.Contains(_state.CurrentUser?.Role_Role);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}