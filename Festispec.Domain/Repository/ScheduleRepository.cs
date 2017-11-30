using System.Data.Entity;
using System.Linq;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository
{
    public class ScheduleRepository : RepositoryBase<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(DbContext dbContext) : base(dbContext)
        {
        }


        public override IQueryable<Schedule> Get()
        {
            return base.Get();
        }

        public override Schedule Add(Schedule entity)
        {
            entity = CleanRelations(entity);

            return base.Add(entity);
        }

        public override Schedule Update(Schedule updated, params object[] keyValues)
        {
            updated = CleanRelations(updated);
            
            return base.Update(updated, keyValues);
        }

        private Schedule CleanRelations(Schedule entity)
        {
            return entity;
        }
    }
}