using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository.Factory
{
    public class InspectionRepositoryFactory : RepositoryFactory<Inspection>, IInspectionRepositoryFactory
    {
        public InspectionRepositoryFactory(FestispecContainer dbContext) : base(dbContext)
        {
        }

        public override IGenericRepository<Inspection> CreateRepository()
        {
            return new InspectionRepository(DbContext);
        }
    }
}