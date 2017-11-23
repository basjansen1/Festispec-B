using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository.Factory
{
    public class LoginRepositoryFactory : RepositoryFactoryBase<ILoginRepository, Employee>, ILoginRepositoryFactory
    {
        public override ILoginRepository CreateRepository()
        {
            return new LoginRepository(GetDbContext());
        }
    }
}
