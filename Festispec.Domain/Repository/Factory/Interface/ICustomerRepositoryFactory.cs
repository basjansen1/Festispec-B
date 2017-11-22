using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository.Factory.Interface
{
    public interface ICustomerRepositoryFactory : IRepositoryFactory<ICustomerRepository, Customer>
    {
    }
}
