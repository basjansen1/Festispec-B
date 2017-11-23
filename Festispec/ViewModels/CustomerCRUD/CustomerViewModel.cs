using Festispec.Domain.Repository.Factory.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festispec.ViewModels.CustomerCRUD
{
    class CustomerViewModel : EntityViewModelBase<ICustomerRepositoryFactory, Domain.Customer>
    {

        public CustomerViewModel(ICustomerRepositoryFactory repositoryFactory) : base(repositoryFactory)
        {
        }

        public CustomerViewModel(ICustomerRepositoryFactory repositoryFactory, Domain.Customer entity)
            : base(repositoryFactory, entity)
        {
        }

        public int Id => Entity.Id;


        public string CompanyName
        {
            get { return Entity.CompanyName; }
            set
            {
                Entity.CompanyName = value;
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


        public override void Save()
        {

            using (var CustomerRepository = RepositoryFactory.CreateRepository())
            {
                var updated = UpdatedEntity.Id == 0 ? CustomerRepository.Add(UpdatedEntity) : CustomerRepository.Update(UpdatedEntity, UpdatedEntity.Id);
            }
        }

        public override void Delete()
        {
            using (var CustomerRepository = RepositoryFactory.CreateRepository())
            {
                CustomerRepository.Delete(Entity);
            }
        }

        public override Domain.Customer Copy()
        {
            return new Domain.Customer
            {
                Id = Id,
                Email = Email,
                City = City,
                CompanyName = CompanyName,
                Country = Country,
                HouseNumber = HouseNumber,
                IBAN = IBAN,
                Municipality = Municipality,
                PostalCode = PostalCode,
                Street = Street,
                Telephone = Telephone,
                Location = Location,
                Long = Long,
                Lat = Lat,
            };
        }
    }
}
