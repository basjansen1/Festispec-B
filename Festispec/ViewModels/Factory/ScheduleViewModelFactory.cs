using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.Schedule;

namespace Festispec.ViewModels.Factory
{
    public class ScheduleViewModelFactory : IScheduleViewModelFactory
    {
        private readonly IScheduleRepositoryFactory _ScheduleRepositoryFactory;
        public ScheduleViewModelFactory(IScheduleRepositoryFactory ScheduleRepositoryFactory)
        {
            _ScheduleRepositoryFactory = ScheduleRepositoryFactory;
        }

        public ScheduleViewModel CreateViewModel()
        {
            return new ScheduleViewModel(_ScheduleRepositoryFactory);
        }

        public ScheduleViewModel CreateViewModel(Domain.Schedule entity)
        {
            return new ScheduleViewModel(_ScheduleRepositoryFactory, entity);
        }
    }
}