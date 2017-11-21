using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository.Factory
{
    public class CustomerRepositoryFactory : RepositoryFactoryBase<Customer>, ICustomerRepositoryFactory
    {
        public override IRepository<Customer> CreateRepository()
        {
            return new CustomerRepository(GetDbContext());
        }
    }
}