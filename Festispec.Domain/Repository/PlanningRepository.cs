using System.Data.Entity;
using System.Linq;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository
{
    public class PlanningRepository : RepositoryBase<Planning>, IPlanningRepository
    {
        public PlanningRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<Planning> Get()
        {
            return base.Get().Include(planning => planning.Inspector).Include(planning => planning.Inspection);
        }

        public IQueryable<Planning> GetByInspectionId(int inspectionId)
        {
            return Get().Where(planning => planning.Inspection_Id == inspectionId);
        }
    }
}