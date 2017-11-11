using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository
{
    public class InspectionRepository : GenericRepository<Inspection>, IInspectionRepository
    {
        public InspectionRepository(FestispecContainer dbContext) : base(dbContext)
        {
        }
    }
}