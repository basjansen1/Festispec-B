using System.Collections.Generic;
using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using System.Data.Entity.Spatial;
using System;
using System.Windows;
using System.Linq;

namespace Festispec.ViewModels.Inspector
{
    public class InspectorViewModel : EntityViewModelBase<IInspectorRepositoryFactory, IInspectorRepository, Domain.Inspector>
    {
        public InspectorViewModel(IInspectorRepositoryFactory repositoryFactory) : base(repositoryFactory)
        {
            if (HiredFrom == default(DateTime))
            {
                HiredFrom = new DateTime(1990, 1, 1);
            }
        }

        public InspectorViewModel(IInspectorRepositoryFactory repositoryFactory, Domain.Inspector entity)
            : base(repositoryFactory, entity)
        {
        }

        public int Id => Entity.Id;


        public string Username
        {
            get { return Entity.Username; }
            set
            {
                Entity.Username = value;
                RaisePropertyChanged();
            }
        }


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
        public Domain.Employee Manager
        {
            get { return Entity.Manager; }
            set
            {
                Entity.Manager = value;
                RaisePropertyChanged();
            }
        }
        public string Password
        {
            get { return Entity.Password; }
            set
            {
                Entity.Password = value;
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
        public EmployeeRole Role
        {
            get { return Entity.Role; }
            set
            {
                Entity.Role = value;
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

        public string Role_Role
        {
            get { return Entity.Role_Role; }
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

        public DateTime HiredFrom
        {
            get { return Entity.HiredFrom; }
            set
            {
                Entity.HiredFrom = value;
                RaisePropertyChanged();
            }
        }
        public DateTime? HiredTo
        {
            get { return Entity.HiredTo; }
            set
            {
                Entity.HiredTo = value;
                RaisePropertyChanged();
            }
        }
        public DateTime? CertificationFrom
        {
            get { return Entity.CertificationFrom; }
            set
            {
                Entity.CertificationFrom = value;
                RaisePropertyChanged();
            }
        }

        public int? Manager_Id
        {
            get { return Entity.Manager_Id; }
            set
            {
                Entity.Manager_Id = value;
                RaisePropertyChanged();
            }
        }

        public DateTime? CertificationTo
        {
            get { return Entity.CertificationTo; }
            set
            {
                Entity.CertificationTo = value;
                RaisePropertyChanged();
            }
        }

        public override bool Save()
        {
            try
            {
                Domain.Inspector updated;
                using (var InspectorRepository = RepositoryFactory.CreateRepository())
                {
                    updated = Id == 0
                        ? InspectorRepository.Add(Entity)
                        : InspectorRepository.Update(Entity, Id);
                }
                
                // First we map the updated values to the entity
                MapValues(updated, Entity);
                // Then we overwrite the original values with the new entity values
                MapValuesToOriginal();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                var ErrorList = (from eve in ex.EntityValidationErrors
                    from ve in eve.ValidationErrors
                    select ve.PropertyName).ToList();
                string joined = string.Join(",", ErrorList.Select(x => x));
                MessageBox.Show("Veld(en) niet (correct) ingevuld: " + joined);
                return false;
            }

            return true;
        }

        public override bool Delete()
        {
            using (var InspectorRepository = RepositoryFactory.CreateRepository())
            {
                return InspectorRepository.Delete(Entity) != 0;
            }
        }
    }
}