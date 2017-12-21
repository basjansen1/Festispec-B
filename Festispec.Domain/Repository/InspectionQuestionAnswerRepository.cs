using System.Data.Entity;
using Festispec.Domain.Repository.Interface;
using System.Linq;

namespace Festispec.Domain.Repository
{
    public class InspectionQuestionAnswerRepository : RepositoryBase<InspectionQuestionAnswer>, IInspectionQuestionAnswerRepository
    {
        public InspectionQuestionAnswerRepository(DbContext dbContext) : base(dbContext)
        {
        }
        public override IQueryable<InspectionQuestionAnswer> Get()
        {
            return base.Get();
        }

        public override InspectionQuestionAnswer Add(InspectionQuestionAnswer entity)
        {
            entity = CleanRelations(entity);

            return base.Add(entity);
        }

        public override InspectionQuestionAnswer Update(InspectionQuestionAnswer updated, params object[] keyValues)
        {
            updated = CleanRelations(updated);

            return base.Update(updated, keyValues);
        }

        private InspectionQuestionAnswer CleanRelations(InspectionQuestionAnswer entity)
        {
            return entity;
        }
    }
}