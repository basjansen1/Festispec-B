using System.Data.Entity;
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
    }
}