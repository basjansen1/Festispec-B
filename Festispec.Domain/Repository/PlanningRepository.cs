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
            return base.Get()
                    .Include(planning => planning.Inspector)
                    .Include(planning => planning.Inspection)
//                .Include(planning => planning.Questions)
                ;
        }

        public IQueryable<Planning> GetByInspectionId(int inspectionId)
        {
            return Get().Where(planning => planning.Inspection_Id == inspectionId);
        }

        public override Planning AddOrUpdate(Planning entity)
        {
            var exists = Get().Any(planning =>
                planning.Inspection_Id == entity.Inspection_Id && 
                planning.Inspector_Id == entity.Inspector_Id &&
                planning.Date == entity.Date);

            return exists
                ? Update(entity, entity.Inspection_Id, entity.Inspector_Id, entity.Date)
                : Add(entity);
        }
    }
}