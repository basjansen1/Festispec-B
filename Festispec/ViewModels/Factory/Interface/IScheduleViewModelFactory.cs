using Festispec.ViewModels.Interface;
using Festispec.ViewModels.Schedule;

namespace Festispec.ViewModels.Factory.Interface
{
    public interface IScheduleViewModelFactory : IViewModelFactory<ScheduleViewModel, Domain.Schedule>
    {
    }
}