using System.Data.Entity;
using System.Linq;
using System.Net.Sockets;
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

        public override Planning Add(Planning entity)
        {
            entity = CleanRelations(entity);
            entity = base.Add(entity);
            LoadRelations(entity);
            
            return entity;
        }

        public override Planning Update(Planning updated, params object[] keyValues)
        {
            updated = CleanRelations(updated);
            base.Update(updated, keyValues);

            // Due to issues with navigation properties.
            // Get the fresh model from the database
            // Load the relations on that model.
            // Map the navigation properties from the fresh model to the referenced model.
            // TODO: Remove this when MapValues
            var entity = Get(keyValues);
            LoadRelations(entity);
            updated.Inspection = entity.Inspection;
            updated.Inspector = entity.Inspector;

            return updated;
        }

        public override int Delete(Planning entity)
        {
            entity = CleanRelations(entity);
            return base.Delete(entity);
        }

        private static Planning CleanRelations(Planning entity)
        {
            if (entity.Inspection != null)
            {
                // Set foreign key and unset the navigation property
                // This is needed because we are working with disconnected entities.
                entity.Inspection_Id = entity.Inspection.Id;
                entity.Inspection = null;
            }

            if (entity.Inspector != null)
            {
                // Set foreign key and unset the navigation property
                // This is needed because we are working with disconnected entities.
                entity.Inspector_Id = entity.Inspector.Id;
                entity.Inspector = null;
            }

            return entity;
        }

        private void LoadRelations(Planning entity)
        {
            DbContext.Entry(entity).Reference(planning => planning.Inspection).Load();
            DbContext.Entry(entity).Reference(planning => planning.Inspector).Load();
            // TODO: Enable when inspection questions
            //DbContext.Entry(entity).Collection(planning => planning.Questions).Load();
        }
    }
}