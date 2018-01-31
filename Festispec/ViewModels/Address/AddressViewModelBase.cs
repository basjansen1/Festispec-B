using System.Data.Entity.Spatial;
using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using Festispec.ViewModels.Interface;

namespace Festispec.ViewModels.Address
{
    public abstract class AddressViewModelBase<TRepositoryFactory, TRepository, TEntity> :
        EntityViewModelBase<TRepositoryFactory, TRepository, TEntity>,
        IAddressViewModel<TEntity>
        where TRepositoryFactory : IRepositoryFactory<TRepository, TEntity>
        where TRepository : IRepository<TEntity>
        where TEntity : class, IAddress, new()
    {
        protected AddressViewModelBase(TRepositoryFactory repositoryFactory) : base(repositoryFactory)
        {
        }

        protected AddressViewModelBase(TRepositoryFactory repositoryFactory, TEntity entity) : base(repositoryFactory,
            entity)
        {
        }

        public int Id => Entity.Id;

        public string Street
        {
            get { return Entity.Street; }
            set
            {
                Entity.Street = value;
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

        public string PostalCode
        {
            get { return Entity.PostalCode; }
            set
            {
                Entity.PostalCode = value;
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

        public string Country
        {
            get { return Entity.Country; }
            set
            {
                Entity.Country = value;
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

        public void MapValues(Domain.Address from, Domain.Address to)
        {
            // Map values
            to.Id = from.Id;
            to.City = from.City;
            to.Country = from.Country;
            to.HouseNumber = from.HouseNumber;
            to.Lat = from.Lat;
            to.Location = from.Location;
            to.Long = from.Long;
            to.Municipality = from.Municipality;
            to.PostalCode = from.PostalCode;
            to.Street = from.Street;
        }
    }
}