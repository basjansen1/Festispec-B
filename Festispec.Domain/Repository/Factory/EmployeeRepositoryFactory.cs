using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository.Factory
{
    public class EmployeeRepositoryFactory : RepositoryFactoryBase<Employee>, IEmployeeRepositoryFactory
    {
        public override IRepository<Employee> CreateRepository()
        {
            return new EmployeeRepository(GetDbContext());
        }
    }
}