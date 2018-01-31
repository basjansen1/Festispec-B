using System.ComponentModel;
using System.Windows.Input;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using Festispec.NavigationService;
using Festispec.ViewModels.Address;
using Festispec.ViewModels.Factory.Interface;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.Generic;
using System.Linq;

namespace Festispec.ViewModels.Inspector
{
    public class InspectorAddOrUpdateViewModel :
        AddressAddOrUpdateViewModelBase<IInspectorViewModelFactory, InspectorViewModel, IInspectorRepository, Domain.Inspector>
    {
        public InspectorAddOrUpdateViewModel(INavigationService navigationService,
            IInspectorRepositoryFactory repositoryFactory,
            IInspectorViewModelFactory inspectorViewModelFactory, IEmployeeRepositoryFactory employeeRepositoryFactory, IGeoRepositoryFactory geoRepositoryFactory)
            : base(navigationService, repositoryFactory, inspectorViewModelFactory, geoRepositoryFactory)
        {
            RegisterCommands();
            using (var employeeRepository = employeeRepositoryFactory.CreateRepository())
            {
                Managers = new[] { new Domain.Employee { Id = -1 } }.Concat(employeeRepository.Get()
                    .Where(e => e.Role_Role == "Manager" && e.Id != EntityViewModel.Id).ToList());
            }
        }

        public ICommand NavigateToScheduleAddCommand { get; set; }
        public ICommand NavigateToScheduleUpdateCommand { get; set; }
        public ICommand ScheduleDeleteCommand { get; set; }
        public IEnumerable<Domain.Employee> Managers { get; }
        private void RegisterCommands()
        {
            NavigateToScheduleAddCommand =
                new RelayCommand(
                    () =>
                    {
                        EntityViewModel.SelectedSchedule = null;
                        NavigationService.NavigateTo(Routes.Routes.InspectorScheduleAdd, EntityViewModel);
                    },
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

            base.Save();
        }

        public override void Cancel()
        {
            base.Cancel();
        }
    }
}