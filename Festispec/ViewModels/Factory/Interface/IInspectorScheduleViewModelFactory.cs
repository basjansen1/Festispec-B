using Festispec.ViewModels.Interface;
using Festispec.ViewModels.Inspector;

namespace Festispec.ViewModels.Factory.Interface
{
    public interface IInspectorScheduleViewModelFactory : IViewModelFactory<InspectorScheduleViewModel, Domain.Schedule>
    {
    }
}