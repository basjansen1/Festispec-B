using System.ComponentModel;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.NavigationService;
using Festispec.ViewModels.Factory.Interface;

namespace Festispec.ViewModels.Inspector
{
    public class InspectorScheduleAddViewModel :
        InspectorScheduleAddOrUpdateViewModel
    {
        public InspectorScheduleAddViewModel(INavigationService navigationService,
            IInspectorScheduleRepositoryFactory repositoryFactory, IInspectorScheduleViewModelFactory viewModelFactory)
            : base(navigationService, repositoryFactory, viewModelFactory)
        {
        }

        public override void OnNavigationServicePropertyChange(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "CurrentRoute") return;

            if (NavigationService.CurrentRoute != Routes.Routes.InspectorScheduleAdd) return;

            UpdateEntityViewModelFromNavigationParameter();
        }

        public override void Save()
        {
            //TODO: Validation

            InspectorViewModel.Schedule.Add(EntityViewModel);

            GoBack();
        }
    }
}