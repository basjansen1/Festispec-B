using Festispec.Domain;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Festispec.ViewModels.RequestProcessing
{
    public class InspectionVM : ViewModelBase
    {
        // getters and setters
        public string Name
        {
            get
            {
                return _inspection.Name;
            }
            set
            {
                _inspection.Name = value;
                RaisePropertyChanged("Name");
            }
        }

        public string Website
        {
            get
            {
                return _inspection.Website;
            }
            set
            {
                _inspection.Website = value;
                RaisePropertyChanged("Website");
            }
        }

        public DateTime StartDate
        {
            get
            {
                return _inspection.Start;
            }
            set
            {
                _inspection.Start = value;
                RaisePropertyChanged("StartDate");
            }
        }

        public DateTime EndDate
        {
            get
            {
                return _inspection.End;
            }
            set
            {
                _inspection.End = value;
                RaisePropertyChanged("EndDate");
            }
        }
        public string City
        {
            get
            {
                return _inspection.City;
            }
            set
            {
                _inspection.City = value;
                RaisePropertyChanged("City");
            }
        }
        public string Street
        {
            get
            {
                return _inspection.Street;
            }
            set
            {
                _inspection.Street = value;
                RaisePropertyChanged("Street");
            }
        }

        public string PostalCode
        {
            get
            {
                return _inspection.PostalCode;
            }
            set
            {
                _inspection.PostalCode = value;
                RaisePropertyChanged("PostalCode");
            }
        }

        public string HouseNumber
        {
            get
            {
                return _inspection.HouseNumber;
            }
            set
            {
                _inspection.HouseNumber = value;
                RaisePropertyChanged("HouseNumber");
            }
        }

        public string Country
        {
            get
            {
                return _inspection.Country;
            }
            set
            {
                _inspection.Country = value;
                RaisePropertyChanged("Country");
            }
        }
        public string Status
        {
            get
            {
                return _inspection.Status_Status;
            }
            set
            {
                _inspection.Status_Status = value;
                RaisePropertyChanged("Status");
            }
        }

        public int CustomerId
        {
            get
            {
                return _inspection.Customer_Id;
            }
            set
            {
                _inspection.Customer_Id = value;
            }
        }

        public DbGeography Location
        {
            get
            {
                return _inspection.Location;
            }
            set
            {
                _inspection.Location = value;
            }
        }

        public string Municipality
        {
            get
            {
                return _inspection.Municipality;
            }
            set
            {
                _inspection.Municipality = value;
            }
        }

        public Customer Customer
        {
            get
            {
                return _inspection.Customers;
            }
            set
            {
                Customer = value;
                RaisePropertyChanged("Customer");
            }
        }

        // field
        private Inspection _inspection;

        // constructors

        public InspectionVM()
        {
            _inspection = new Inspection();
        }

        public InspectionVM(Inspection i)
        {
            _inspection = i;
        }

        public Inspection toModel()
        {
            return _inspection;
        }
    }
}
