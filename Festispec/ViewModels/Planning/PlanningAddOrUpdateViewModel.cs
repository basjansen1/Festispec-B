using System.ComponentModel;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using Festispec.NavigationService;
using Festispec.ViewModels.Factory.Interface;

namespace Festispec.ViewModels.Planning
{
    public class PlanningAddOrUpdateViewModel :
        AddOrUpdateViewModelBase<IPlanningViewModelFactory, PlanningViewModel, IPlanningRepository, Domain.Planning>
    {
        protected readonly IInspectorRepositoryFactory InspectorRepositoryFactory;

        public PlanningAddOrUpdateViewModel(INavigationService navigationService,
            IPlanningRepositoryFactory repositoryFactory,
            IPlanningViewModelFactory viewModelFactory, IInspectorRepositoryFactory inspectorRepositoryFactory) : base(
            navigationService, repositoryFactory, viewModelFactory)
        {
            InspectorRepositoryFactory = inspectorRepositoryFactory;
        }

        public override void OnNavigationServicePropertyChange(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != nameof(NavigationService.CurrentRoute)) return;

            if (NavigationService.CurrentRoute != Routes.Routes.PlanningAdd &&
                NavigationService.CurrentRoute != Routes.Routes.PlanningUpdate) return;

            UpdateEntityViewModelFromNavigationParameter();
        }

        public override void Save()
        {
            // TODO: Validation

            var saved = EntityViewModel.Save();

            if (saved) GoBack();
        }

        public override void GoBack()
        {
            base.GoBack(EntityViewModel.Inspection);
        }
    }
}