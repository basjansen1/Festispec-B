using System.Data.Entity;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository
{
    public class InspectorRepository : RepositoryBase<Inspector>, IInspectorRepository
    {
        public InspectorRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}