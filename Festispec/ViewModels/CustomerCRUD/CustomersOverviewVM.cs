using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festispec.ViewModels.CustomerCRUD
{
    public class CustomersOverviewVM : ViewModelBase
    {
        public ObservableCollection<CustomerVM> Customers { get; set; }

        public CustomersOverviewVM()
        {
            Customers = new ObservableCollection<CustomerVM>();
            Customers.Add(new CustomerVM
            {
                Name = "Teun",
                Address = "Sint-Oedenrode",
                EmailAddress = "GMAIL"
            }
                );
        }
    }
}
