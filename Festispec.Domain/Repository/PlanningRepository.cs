using System.Data.Entity;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository
{
    public class PlanningRepository : RepositoryBase<Planning>, IPlanningRepository
    {
        public PlanningRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}