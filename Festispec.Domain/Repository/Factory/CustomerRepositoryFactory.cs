using Festispec.Domain.Repository.Factory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository.Factory
{
    public class CustomerRepositoryFactory : RepositoryFactoryBase<ICustomerRepository, Customer>, ICustomerRepositoryFactory
    {
        public override ICustomerRepository CreateRepository()
        {
            return new CustomerRepository(GetDbContext());
        }

        public CustomerRepositoryFactory(bool isOnline) : base(isOnline)
        {
        }
    }
}
