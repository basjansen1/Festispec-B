using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository.Factory
{
    public class LoginRepositoryFactory : RepositoryFactoryBase<Employee>, ILoginRepositoryFactory
    {
        public override IRepository<Employee> CreateRepository()
        {
            return new LoginRepository(GetDbContext());
        }
    }
}
