using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository.Factory
{
    public class ScheduleRepositoryFactory : RepositoryFactoryBase<IScheduleRepository, Schedule>, IScheduleRepositoryFactory
    {
        public override IScheduleRepository CreateRepository()
        {
            return new ScheduleRepository(GetDbContext());
        }
    }
}