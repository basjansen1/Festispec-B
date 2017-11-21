using System.Collections.Generic;
using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using System.Data.Entity.Spatial;
using System;

namespace Festispec.ViewModels.Inspector
{
    public class InspectorViewModel : EntityViewModelBase<IInspectorRepositoryFactory, Domain.Inspector>
    {
        public InspectorViewModel(IInspectorRepositoryFactory repositoryFactory) : base(repositoryFactory)
        {
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

        public override void Save()
        {

            using (var InspectorRepository = RepositoryFactory.CreateRepository())
            {
                var updated = UpdatedEntity.Id == 0
                    ? InspectorRepository.Add(UpdatedEntity)
                    : InspectorRepository.Update(UpdatedEntity, UpdatedEntity.Id);
            }
        }

        public override void Delete()
        {
            using (var InspectorRepository = RepositoryFactory.CreateRepository())
            {
                InspectorRepository.Delete(Entity);
            }
        }

        public override Domain.Inspector Copy()
        {
            return new Domain.Inspector
            {
                Id = Id,
                Email = Email,
                City = City,
                Username = Username,
                Country = Country,
                FirstName = FirstName,
                HouseNumber = HouseNumber,
                IBAN = IBAN,
                LastName = LastName,
                Manager_Id = Manager_Id,
                Manager = Manager,
                Password = Password,
                Municipality = Municipality,
                PostalCode = PostalCode,
                Role_Role = Role_Role,
                Role = Role,
                Street = Street,
                Telephone = Telephone,
                Location = Location,
                Long = Long,
                Lat = Lat,
                HiredFrom = HiredFrom,
                HiredTo = HiredTo,
                CertificationFrom = CertificationFrom,
                CertificationTo = CertificationTo
            };
        }
    }
}