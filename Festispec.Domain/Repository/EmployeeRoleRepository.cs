using System.Data.Entity;
using System.Linq;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository
{
    public class EmployeeRoleRepository : RepositoryBase<EmployeeRole>, IEmployeeRoleRepository
    {
        public EmployeeRoleRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}