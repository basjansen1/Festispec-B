using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using Festispec.NavigationService;
using Festispec.ViewModels.Schedule;
using Festispec.ViewModels.Factory.Interface;

namespace Festispec.ViewModels.Schedules
{
    public class ScheduleUpdateViewModel :
        AddOrUpdateViewModelBase<IScheduleViewModelFactory, ScheduleViewModel, IScheduleRepository, Domain.Schedule>
    {
        public ScheduleUpdateViewModel(INavigationService navigationService,
            IScheduleRepositoryFactory repositoryFactory,
            IScheduleViewModelFactory scheduleViewModelFactory)
            : base(navigationService, repositoryFactory, scheduleViewModelFactory)
        {
            
        }

        public IEnumerable<Domain.Schedule> Managers { get; }

        public override void OnNavigationServicePropertyChange(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "CurrentRoute") return;

            if (NavigationService.CurrentRoute != Routes.Routes.ScheduleUpdate) return;

            UpdateEntityViewModelFromNavigationParameter();
        }

        public override void Save()
        {

            // TODO: Validation
            var saved = EntityViewModel.Save();

            if (saved) NavigationService.GoBack(EntityViewModel);
        }
    }
}