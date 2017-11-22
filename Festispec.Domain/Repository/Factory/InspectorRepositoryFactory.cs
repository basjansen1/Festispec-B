using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository.Factory
{
    public class InspectorRepositoryFactory : RepositoryFactoryBase<IInspectorRepository, Inspector>, IInspectorRepositoryFactory
    {
        public override IInspectorRepository CreateRepository()
        {
            return new InspectorRepository(GetDbContext());
        }
    }
}