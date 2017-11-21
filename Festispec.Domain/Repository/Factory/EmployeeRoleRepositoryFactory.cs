using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository.Factory
{
    public class EmployeeRoleRepositoryFactory : RepositoryFactoryBase<EmployeeRole>, IEmployeeRoleRepositoryFactory
    {
        public override IRepository<EmployeeRole> CreateRepository()
        {
            return new EmployeeRoleRepository(GetDbContext());
        }
    }
}