using System.Data.Entity;
using Festispec.Domain.Repository.Interface;
using System.Linq;

namespace Festispec.Domain.Repository
{
    public class InspectionRepository : RepositoryBase<Inspection>, IInspectionRepository
    {
        public InspectionRepository(DbContext dbContext) : base(dbContext)
        {
        }
        public override IQueryable<Inspection> Get()
        {
            return base.Get().Include(inspection => inspection.Customers);
        }

    }
}