using Festispec.Views.CustomerCRUD;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Festispec.ViewModels.CustomerCRUD
{
    public class AddCustomerVM : ViewModelBase
    {
        public ICommand AddCustomer { get; set; }
        public ICommand BackCommand { get; set; }
        
        public AddCustomerVM()
        {
            AddCustomer = new RelayCommand(AddCustomerToList);
            BackCommand = new RelayCommand(ReturnToMenu);
        }

        private void ReturnToMenu()
        {
            var window = new CustomersOverviewWindow();
            window.Show();
            Application.Current.MainWindow.Close();
        }

        private void AddCustomerToList()
        {

            //TODO: Add customer to database
        }


    }
}
