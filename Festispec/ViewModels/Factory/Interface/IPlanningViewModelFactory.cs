using Festispec.ViewModels.Planning;

namespace Festispec.ViewModels.Factory.Interface
{
    public interface IPlanningViewModelFactory : IViewModelFactory<PlanningViewModel, Domain.Planning>
    {
        PlanningViewModel CreateViewModelForInspection(int inspectionId);
    }
}