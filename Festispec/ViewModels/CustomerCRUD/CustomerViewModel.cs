using System.Collections.Generic;
using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using System.Data.Entity.Spatial;
using System;
using System.Windows;
using System.Linq;

namespace Festispec.ViewModels.Customer
{
    public class CustomerViewModel : EntityViewModelBase<ICustomerRepositoryFactory, ICustomerRepository, Domain.Customer>
    {
        public CustomerViewModel(ICustomerRepositoryFactory repositoryFactory) : base(repositoryFactory)
        {
           
        }

        public CustomerViewModel(ICustomerRepositoryFactory repositoryFactory, Domain.Customer entity)
            : base(repositoryFactory, entity)
        {
        }

        public int Id => Entity.Id;

        public string City
        {
            get { return Entity.City; }
            set
            {
                Entity.City = value;
                RaisePropertyChanged();
            }
        }

        public string Email
        {
            get { return Entity.Email; }
            set
            {
                Entity.Email = value;
                RaisePropertyChanged();
            }
        }

        public string Country
        {
            get { return Entity.Country; }
            set
            {
                Entity.Country = value;
                RaisePropertyChanged();
            }
        }

        public string FirstName
        {
            get { return Entity.FirstName; }
            set
            {
                Entity.FirstName = value;
                RaisePropertyChanged();

            }
        }

        public string HouseNumber
        {
            get { return Entity.HouseNumber; }
            set
            {
                Entity.HouseNumber = value;
                RaisePropertyChanged();
            }
        }
        public string IBAN
        {
            get { return Entity.IBAN; }
            set
            {
                Entity.IBAN = value;
                RaisePropertyChanged();
            }
        }

        public string LastName
        {
            get { return Entity.LastName; }
            set
            {
                Entity.IBAN = value;
                RaisePropertyChanged();
            }
        }

        public string Name
        {
            get { return Entity.Name; }

            set
            {
                Entity.Name = value;
                RaisePropertyChanged();
            }
        }


        public string Municipality
        {
            get { return Entity.Municipality; }
            set
            {
                Entity.Municipality = value;
                RaisePropertyChanged();
            }
        }
        public string PostalCode
        {
            get { return Entity.PostalCode; }
            set
            {
                Entity.PostalCode = value;
                RaisePropertyChanged();
            }
        }

        public string Street
        {
            get { return Entity.Street; }
            set
            {
                Entity.Street = value;
                RaisePropertyChanged();
            }
        }
        public string Telephone
        {
            get { return Entity.Telephone; }
            set
            {
                Entity.Telephone = value;
                RaisePropertyChanged();
            }
        }



        public DbGeography Location
        {
            get { return Entity.Location; }
            set
            {
                Entity.Location = value;
                RaisePropertyChanged();
            }
        }

        public double Long
        {
            get { return Entity.Long; }
            set
            {
                Entity.Long = value;
                RaisePropertyChanged();
            }
        }

        public double Lat
        {
            get { return Entity.Lat; }
            set
            {
                Entity.Lat = value;
                RaisePropertyChanged();
            }
        }

        public ICollection<Inspection> Inspections
        {
            get
            {
                return Entity.Inspections;
            }
            set
            {
                Entity.Inspections = value;
                RaisePropertyChanged();
            }
        }

        public String KVK
        {
            get { return Entity.KVK; }
            set {
                Entity.KVK = value;
                RaisePropertyChanged();
                }
        }

        public ICollection<Note> Notes
        {
            get { return Entity.Notes; }
            set
            {
                Entity.Notes = value;
                RaisePropertyChanged();
            }
        }



        public override bool Save()
        {

            using (var InspectorRepository = RepositoryFactory.CreateRepository())
            {
                try
                {
                    var updated = Id == 0
                        ? InspectorRepository.Add(Entity)
                        : InspectorRepository.Update(Entity, Id);
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    List<string> ErrorList = new List<string>();
                    foreach (var eve in ex.EntityValidationErrors)
                    {
                        foreach (var ve in eve.ValidationErrors)
                        {
                            ErrorList.Add(ve.PropertyName);
                        }
                    }
                    string joined = string.Join(",", ErrorList.Select(x => x));
                    MessageBox.Show("Veld(en) niet (correct) ingevuld: " + joined);
                    return false;
                }
            }
            RaisePropertyChanged();
            return true;
        }

        public override bool Delete()
        {
            using (var CustomerRepository = RepositoryFactory.CreateRepository())
            {
                RaisePropertyChanged();
                return CustomerRepository.Delete(Entity) != 0;
            }
        }
    }
}