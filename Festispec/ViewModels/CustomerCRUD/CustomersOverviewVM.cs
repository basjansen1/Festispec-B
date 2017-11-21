using Festispec.Views.CustomerCRUD;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Festispec.ViewModels.NavigationService;
using System.Linq;

namespace Festispec.ViewModels.CustomerCRUD
{
    public class CustomersOverviewVM : ViewModelBase
    {
        public ICommand OpenAddCustomerWindow { get; set; }
        public ICommand OpenMainMenuWindow { get; set; }
        public ICommand OpenEditCustomerWindow { get; set; }

        public ObservableCollection<CustomerVM> Customers { get; set; }

        public CustomersOverviewVM()
        {
            Customers = new ObservableCollection<CustomerVM>();
            OpenAddCustomerWindow = new RelayCommand(AddCustomerWindow);
            OpenMainMenuWindow = new RelayCommand(MainMenuWindow);
            OpenEditCustomerWindow = new RelayCommand(EditCustomerWindow);
        }

        private void MainMenuWindow()
        {   
            var window = new MainWindow();
            window.Show();
            Application.Current.MainWindow.Close();
        }

        private void EditCustomerWindow()
        {
            var window = new EditCustomerWindow();
            window.Show();
            Application.Current.MainWindow.Close();
        }

        private void AddCustomerWindow()
        {
            var window = new AddCustomerWindow();
            window.Show();
            Application.Current.MainWindow.Close();
        }
    }
}
