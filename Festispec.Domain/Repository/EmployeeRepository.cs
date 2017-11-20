using System.Data.Entity;
using System.Linq;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DbContext dbContext) : base(dbContext)
        {
        }


        public override IQueryable<Employee> Get()
        {
            return base.Get().AsNoTracking();
        }

        public override int Delete(Employee entity)
        {
            return base.Delete(entity);
        }
    }
}