using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository.Factory
{
    public class CustomerRepositoryFactory : RepositoryFactoryBase<ICustomerRepository, Customer>, ICustomerRepositoryFactory
    {
        public override ICustomerRepository CreateRepository()
        {
            return new CustomerRepository(GetDbContext());
        }
    }
}