using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository.Factory
{
    public class EmployeeRepositoryFactory : RepositoryFactoryBase<IEmployeeRepository, Employee>, IEmployeeRepositoryFactory
    {
        public override IEmployeeRepository CreateRepository()
        {
            return new EmployeeRepository(GetDbContext());
        }
    }
}