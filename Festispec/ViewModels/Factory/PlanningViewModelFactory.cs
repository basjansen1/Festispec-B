using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.Planning;

namespace Festispec.ViewModels.Factory
{
    public class PlanningViewModelFactory : IPlanningViewModelFactory
    {
        private readonly IPlanningRepositoryFactory _planningRepositoryFactory;

        public PlanningViewModelFactory(IPlanningRepositoryFactory planningRepositoryFactory)
        {
            _planningRepositoryFactory = planningRepositoryFactory;
        }

        public PlanningViewModel CreateViewModel()
        {
            return new PlanningViewModel(_planningRepositoryFactory);
        }

        public PlanningViewModel CreateViewModel(Domain.Planning entity)
        {
            return new PlanningViewModel(_planningRepositoryFactory, entity);
        }

        public PlanningViewModel CreateViewModelForInspection(int inspectionId)
        {
            return new PlanningViewModel(_planningRepositoryFactory,
                new Domain.Planning {Inspection_Id = inspectionId});
        }
    }
}