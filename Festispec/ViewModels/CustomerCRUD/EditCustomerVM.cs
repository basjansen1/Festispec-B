using Festispec.Views.CustomerCRUD;
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
    public class EditCustomerVM
    {

        public String Name { get; set; }
        public String Email { get; set; }
        public String Address { get; set; }
        public int Telefone { get; set; }
        public String Language { get; set; }


        
        public ICommand SaveCustomer { get; set; }

        public EditCustomerVM()
        {
            SaveCustomer = new RelayCommand(CustomersOverView);
        }

        private void CustomersOverView()
        {
            var window = new CustomersOverviewWindow();
            window.Show();
            Application.Current.MainWindow.Close();
        }
    }
}
