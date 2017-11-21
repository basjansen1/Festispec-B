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
            return base.Get().Include(e => e.Manager);
        }

        public override Employee Add(Employee entity)
        {
            if(entity.Role != null)
            {
                if(entity.Role_Role == null)
                    entity.Role_Role = entity.Role.Role;
                entity.Role = null;
            }

            if(entity.Manager != null)
            {
                if (entity.Manager_Id == null)
                    entity.Manager_Id = entity.Manager.Id;
                entity.Manager = null;
            }

            return base.Add(entity);
        }
    }
}