using Festispec.ViewModels.Interface;
using Festispec.ViewModels.Inspector;

namespace Festispec.ViewModels.Factory.Interface
{
    public interface IInspectorViewModelFactory : IViewModelFactory<InspectorViewModel, Domain.Inspector>
    {
    }
}