using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using Festispec.ViewModels.Factory.Interface;
using Festispec.NavigationService;

namespace Festispec.ViewModels.Inspector
{
    public class InspectorScheduleAddOrUpdateViewModel :
        AddOrUpdateViewModelBase
            <IInspectorScheduleViewModelFactory, InspectorScheduleViewModel, IInspectorScheduleRepository, Schedule
                >
    {
        protected InspectorViewModel InspectorViewModel;

        public InspectorScheduleAddOrUpdateViewModel(INavigationService navigationService,
            IInspectorScheduleRepositoryFactory repositoryFactory, 
            IInspectorScheduleViewModelFactory viewModelFactory)
            : base(navigationService, repositoryFactory, viewModelFactory)
        {
            
        }

        public override void OnNavigationServicePropertyChange(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "CurrentRoute") return;

            if (NavigationService.CurrentRoute != Routes.Routes.InspectorScheduleAddOrUpdate) return;

            UpdateEntityViewModelFromNavigationParameter();
        }

        protected override void UpdateEntityViewModelFromNavigationParameter()
        {
            var inspectorViewModel = NavigationService.Parameter as InspectorViewModel;
            if (inspectorViewModel == null) return;

            InspectorViewModel = inspectorViewModel;

            if (InspectorViewModel.SelectedSchedule != null)
            {
                EntityViewModel = InspectorViewModel.SelectedSchedule;
            }
            else
            {
                EntityViewModel = ViewModelFactory.CreateViewModel();

                EntityViewModel.Inspector = InspectorViewModel.Entity;
                EntityViewModel.Inspector_Id = inspectorViewModel.Id;
            }
        }

        public override void Save()
        {
            //TODO: Validation

            // Map updated fields
            EntityViewModel.NotAvailableFrom = EntityViewModel.NotAvailableFrom;
            EntityViewModel.NotAvailableTo = EntityViewModel.NotAvailableTo;
            GoBack();
        }

        public override void GoBack()
        {
            base.GoBack(InspectorViewModel);
        }
    }
}