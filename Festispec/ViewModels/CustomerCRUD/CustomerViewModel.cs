using System.Collections.Generic;
using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using System;
using System.Windows;
using System.Linq;
using Festispec.ViewModels.Address;

namespace Festispec.ViewModels.Customer
{
    public class CustomerViewModel : AddressViewModelBase<ICustomerRepositoryFactory, ICustomerRepository, Domain.Customer>
    {
        public CustomerViewModel(ICustomerRepositoryFactory repositoryFactory) : base(repositoryFactory)
        {
           
        }

        public CustomerViewModel(ICustomerRepositoryFactory repositoryFactory, Domain.Customer entity)
            : base(repositoryFactory, entity)
        {
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

        public string FirstName
        {
            get { return Entity.FirstName; }
            set
            {
                Entity.FirstName = value;
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
                Entity.LastName = value;
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

        public string Telephone
        {
            get { return Entity.Telephone; }
            set
            {
                Entity.Telephone = value;
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
            try
            {
                Domain.Customer updated;
                using (var customerRepository = RepositoryFactory.CreateRepository())
                {
                    updated = Id == 0
                        ? customerRepository.Add(Entity)
                        : customerRepository.Update(Entity, Id);
                }

                // First we map the updated values to the entity
                MapValues(updated, Entity);
                // Then we overwrite the original values with the new entity values
                MapValuesToOriginal();
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

            RaisePropertyChanged();
            return true;
        }
    }
}