using System.Data.Entity.Spatial;
using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using Festispec.ViewModels.Address;
using Festispec.ViewModels.Interface;

namespace Festispec.ViewModels.Contact
{
    public abstract class ContactViewModelBase<TRepositoryFactory, TRepository, TEntity> :
        AddressViewModelBase<TRepositoryFactory, TRepository, TEntity>,
        IContactViewModel<TEntity>
        where TRepositoryFactory : IRepositoryFactory<TRepository, TEntity>
        where TRepository : IRepository<TEntity>
        where TEntity : class, IContact, new()
    {
        protected ContactViewModelBase(TRepositoryFactory repositoryFactory) : base(repositoryFactory)
        {
        }

        protected ContactViewModelBase(TRepositoryFactory repositoryFactory, TEntity entity) : base(repositoryFactory,
            entity)
        {
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

        public string LastName
        {
            get { return Entity.LastName; }
            set
            {
                Entity.LastName = value;
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

        public string Telephone
        {
            get { return Entity.Telephone; }
            set
            {
                Entity.Telephone = value;
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

        public void MapValues(Domain.Contact from, Domain.Contact to)
        {
            // Call map values on parent model
            base.MapValues(from, to);

            // Map values
            to.FirstName = from.FirstName;
            to.LastName = from.LastName;
            to.Email = from.Email;
            to.Telephone = from.Telephone;
            to.IBAN = from.IBAN;
        }
    }
}