using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository.Factory
{
    public class InspectorRepositoryFactory : RepositoryFactoryBase<IInspectorRepository, Inspector>, IInspectorRepositoryFactory
    {
        public InspectorRepositoryFactory(bool isOnline) : base(isOnline)
        {
        }

        public override IInspectorRepository CreateRepository()
        {
            return new InspectorRepository(GetDbContext());
        }
    }
}