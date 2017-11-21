using Festispec.Domain;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festispec.ViewModels.InspectionProcessing
{
    public class CustomerVM : ViewModelBase
    {
        public string Telephone
        {
            get
            {
                return _customer.Telephone;
            }
        }

        public string FirstName
        {
            get
            {
                return _customer.FirstName;
            }
            set
            {
                _customer.FirstName = value;
                RaisePropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get
            {
                return _customer.LastName;
            }
            set
            {
                _customer.FirstName = value;
                RaisePropertyChanged("LastName");
            }
        }

        public string FullName
        {
            get
            {
                return _customer.FirstName + _customer.LastName;
            }
        }

        public string PostalCode
        {
            get
            {
                return _customer.PostalCode;
            }
            set
            {
                _customer.PostalCode = value;
                RaisePropertyChanged("PostalCode");
            }
        }

        public string Street
        {
            get
            {
                return _customer.Street;
            }
            set
            {
                _customer.Street = value;
                RaisePropertyChanged("Street");
            }
        }

        public string City
        {
            get
            {
                return _customer.City;
            }
            set
            {
                _customer.City = value;
                RaisePropertyChanged("City");
            }
        }

        public string HouseNumber
        {
            get
            {
                return _customer.HouseNumber;
            }
            set
            {
                _customer.HouseNumber = value;
                RaisePropertyChanged("HouseNumber");
            }
        }

        public string Email
        {
            get
            {
                return _customer.Email;
            }
            set
            {
                _customer.Email = value;
                RaisePropertyChanged("Email");
            }
        }

        public string IBAN
        {
            get
            {
                return _customer.IBAN;
            }
            set
            {
                _customer.IBAN = value;
                RaisePropertyChanged("IBAN");
            }
        }

        public string Country
        {
            get
            {
                return _customer.Country;
            }
            set
            {
                _customer.Country = value;
                RaisePropertyChanged("Country");
            }
        }

        private Customer _customer;

        public CustomerVM()
        {
            _customer = new Customer();
        }

        public CustomerVM(Customer i)
        {
            _customer = i;
        }

        public Customer ToModel()
        {
            return _customer;
        }
    }
}
