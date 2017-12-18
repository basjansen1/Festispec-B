using Festispec.ViewModels.Interface;
using Festispec.ViewModels.Inspection;

namespace Festispec.ViewModels.Factory.Interface
{
    public interface IInspectionViewModelFactory : IViewModelFactory<InspectionVM, Domain.Inspection>
    {
    }
}