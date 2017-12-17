using Festispec.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;

namespace Festispec.Web.Models
{
    public class InspectionViewModel
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

        public double Lat
        {
            get
            {
                return _inspection.Lat;
            }
            set
            {
                _inspection.Lat = value;
            }
        }

        public double Long
        {
            get
            {
                return _inspection.Long;
            }
            set
            {
                _inspection.Long = value;
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

        public Domain.Customer Customer
        {
            get
            {
                return _inspection.Customers;
            }
            set
            {
                _inspection.Customers = value;
            }
        }

        // field
        private Inspection _inspection;

        // constructors

        public InspectionViewModel()
        {
            _inspection = new Inspection();
        }

        public InspectionViewModel(Inspection i)
        {
            _inspection = i;
        }

        public Inspection toModel()
        {
            return _inspection;
        }

        public int Id => _inspection.Id;


    }
}