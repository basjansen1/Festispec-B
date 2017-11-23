using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository.Factory.Interface
{
    public interface ICustomerRepositoryFactory : IRepositoryFactory<ICustomerRepository, Customer>
    {
    }
}