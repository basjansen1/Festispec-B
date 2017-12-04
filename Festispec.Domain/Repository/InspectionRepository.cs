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

        public override Inspection Add(Inspection entity)
        {
            entity = CleanRelations(entity);
            return base.Add(entity);
        }


        public override Inspection Update(Inspection updated, params object[] keyValues)
        {
            updated = CleanRelations(updated);
            return base.Update(updated, keyValues);
        }

        private static Inspection CleanRelations(Inspection entity)
        {
            if (entity.Customers != null)
            {
                // Set foreign key and unset the navigation property
                // This is needed because we are working with disconnected entities.
                entity.Customer_Id = entity.Customers.Id;
                entity.Customers = null;
            }

            return entity;
        }
    }
}