using System.ComponentModel;
using System.Windows.Input;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using Festispec.NavigationService;
using Festispec.ViewModels.Factory.Interface;
using GalaSoft.MvvmLight.CommandWpf;

namespace Festispec.ViewModels.Inspector
{
    public class InspectorAddOrUpdateViewModel :
        AddOrUpdateViewModelBase<IInspectorViewModelFactory, InspectorViewModel, IInspectorRepository, Domain.Inspector>
    {
        public InspectorAddOrUpdateViewModel(INavigationService navigationService,
            IInspectorRepositoryFactory repositoryFactory,
            IInspectorViewModelFactory viewModelFactory)
            : base(navigationService, repositoryFactory, viewModelFactory)
        {
            RegisterCommands();
        }

        public ICommand NavigateToScheduleAddCommand { get; set; }
        public ICommand NavigateToScheduleUpdateCommand { get; set; }
        public ICommand ScheduleDeleteCommand { get; set; }

        private void RegisterCommands()
        {
            NavigateToScheduleAddCommand =
                new RelayCommand(
                    () => NavigationService.NavigateTo(Routes.Routes.InspectorScheduleAdd, EntityViewModel),
                    () => EntityViewModel != null);
            NavigateToScheduleUpdateCommand = new RelayCommand(
                () => NavigationService.NavigateTo(Routes.Routes.InspectorScheduleAddOrUpdate, EntityViewModel),
                () => EntityViewModel.SelectedSchedule != null && !EntityViewModel.SelectedSchedule.IsDeleted);
            ScheduleDeleteCommand = new RelayCommand(() =>
            {
                EntityViewModel.SelectedSchedule.IsDeleted = true;
                EntityViewModel = EntityViewModel;
            }, () => EntityViewModel.SelectedSchedule != null && !EntityViewModel.SelectedSchedule.IsDeleted);
        }

        public override void OnNavigationServicePropertyChange(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != nameof(NavigationService.CurrentRoute)) return;

            if (NavigationService.CurrentRoute != Routes.Routes.InspectorAddOrUpdate) return;

            UpdateEntityViewModelFromNavigationParameter();
        }

        protected override void UpdateEntityViewModelFromNavigationParameter()
        {
            base.UpdateEntityViewModelFromNavigationParameter();

            EntityViewModel.SelectedSchedule = null;
        }

        public override void Save()
        {
            // TODO: Validation

            var saved = EntityViewModel.Save();

            if (saved) GoBack(EntityViewModel);
        }
    }
}