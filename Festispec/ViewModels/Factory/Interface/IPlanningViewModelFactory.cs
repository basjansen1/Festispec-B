using Festispec.Domain;
using Festispec.ViewModels.Planning;

namespace Festispec.ViewModels.Factory.Interface
{
    public interface IPlanningViewModelFactory : IViewModelFactory<PlanningViewModel, Domain.Planning>
    {
        PlanningViewModel CreateViewModelForInspection(Inspection inspection);
    }
}