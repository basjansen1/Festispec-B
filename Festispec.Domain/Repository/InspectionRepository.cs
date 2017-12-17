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

        public void AddQuestion(Inspection inspection, Question question)
        {
            if (question.Id == 0)
            {
                DbContext.Set<Question>().Add(question);
                DbContext.SaveChanges();
            }

            DbContext.Set<InspectionQuestion>()
                .Add(new InspectionQuestion {Inspection_Id = inspection.Id, Question_Id = question.Id});
            DbContext.SaveChanges();
        }
        public void TryAttachQuestion(Inspection inspection, Question question)
        {
            var exists = DbContext.Set<InspectionQuestion>().Any(inspectionQuestion =>
                inspectionQuestion.Inspection_Id == inspection.Id && inspectionQuestion.Question_Id == question.Id);

            if (exists)
                return;

            AttachQuestions(inspection, question);
        }

        public void AttachQuestions(Inspection inspection, Question question)
        {
            DbContext.Set<InspectionQuestion>()
                .Add(new InspectionQuestion { Inspection_Id = inspection.Id, Question_Id = question.Id });
            DbContext.SaveChanges();
        }

        public void DetachQuestions(Inspection inspection, Question question)
        {
            var existing = DbContext.Set<InspectionQuestion>().Find(inspection.Id, question.Id);

            if (existing == null) return;

            DbContext.Entry(existing).State = EntityState.Deleted;
            DbContext.SaveChanges();
        }
    }
}