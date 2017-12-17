using System.Data.Entity;
using System.Linq;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository
{
    public class InspectorScheduleRepository : RepositoryBase<Schedule>, IInspectorScheduleRepository
    {
        public InspectorScheduleRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override Schedule Add(Schedule entity)
        {
            entity = CleanRelations(entity);

            return base.Add(entity);
        }

        public override int Delete(Schedule entity)
        {
            entity = CleanRelations(entity);
            return base.Delete(entity);
        }

        private static Schedule CleanRelations(Schedule entity)
        {
            if (entity.Inspector != null)
            {
                entity.Inspector_Id = entity.Inspector.Id;
                entity.Inspector = null;
            }

            return entity;
        }
    }
}