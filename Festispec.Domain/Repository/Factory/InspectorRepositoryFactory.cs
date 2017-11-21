using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository.Factory
{
    public class InspectorRepositoryFactory : RepositoryFactoryBase<Inspector>, IInspectorRepositoryFactory
    {
        public override IRepository<Inspector> CreateRepository()
        {
            return new InspectorRepository(GetDbContext());
        }
    }
}