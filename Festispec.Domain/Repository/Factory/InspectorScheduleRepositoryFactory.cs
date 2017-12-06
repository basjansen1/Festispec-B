using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository.Factory
{
    public class InspectorScheduleRepositoryFactory : RepositoryFactoryBase<IInspectorScheduleRepository, Schedule>, IInspectorScheduleRepositoryFactory
    {
        public override IInspectorScheduleRepository CreateRepository()
        {
            return new InspectorScheduleRepository(GetDbContext());
        }
    }
}