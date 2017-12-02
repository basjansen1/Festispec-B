using System;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Linq;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository
{
    public class InspectorRepository : RepositoryBase<Inspector>, IInspectorRepository
    {
        public InspectorRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override Inspector Add(Inspector entity)
        {
            entity = CleanRelations(entity);

            return base.Add(entity);
        }

        public override Inspector Update(Inspector updated, params object[] keyValues)
        {
            updated = CleanRelations(updated);

            return base.Update(updated, keyValues);
        }

        private Inspector CleanRelations(Inspector entity)
        {
            // Set default inspecteur role
            entity.Role = null;
            entity.Role_Role = "Inspecteur";

            if (entity.Manager != null)
            {
                if (entity.Manager_Id == null)
                    entity.Manager_Id = entity.Manager.Id;
                entity.Manager = null;
            }

            return entity;
        }

        public IQueryable<Inspector> GetAvailableNearby(DateTime dateAvailable, DbGeography center, int inspectorId = 0)
        {
            return Get()
                // Where inspector has no scheduled time off which covers the date available
                .Where(inspector => !inspector.Schedule.Any(schedule => schedule.NotAvailableFrom > dateAvailable && schedule.NotAvailableTo < dateAvailable))
                // Where inspector has no planning on the date available
                .Where(inspector => inspector.Planning.All(planning => planning.Date != dateAvailable) || inspector.Id == inspectorId)
                // TODO: Where certification date is still valid at dateAvailable
                // TODO: Where hired date is still valid at dateAvailable
                // Order by distance to center
                .OrderBy(inspector => inspector.Location.Distance(center));
        }
    }
}