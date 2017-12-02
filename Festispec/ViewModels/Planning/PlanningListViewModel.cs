using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.NavigationService;
using Festispec.ViewModels.Employees;
using Festispec.ViewModels.Factory.Interface;
using GalaSoft.MvvmLight.CommandWpf;

namespace Festispec.ViewModels.Planning
{
    public class PlanningListViewModel : NavigatableViewModelBase
    {
        private readonly IPlanningRepositoryFactory _planningRepositoryFactory;
        private readonly IPlanningViewModelFactory _planningViewModelFactory;

        private int _inspectionId;

        public PlanningListViewModel(INavigationService navigationService,
            IPlanningRepositoryFactory planningRepositoryFactory, IPlanningViewModelFactory planningViewModelFactory) :
            base(navigationService)
        {
            _planningRepositoryFactory = planningRepositoryFactory;
            _planningViewModelFactory = planningViewModelFactory;

            RegisterCommands();

            UpdateEntityViewModelFromNavigationParameter();
            LoadPlannings();

            NavigationService.PropertyChanged += OnNavigationServicePropertyChanged;
        }

        public ICommand NavigateToAddPlanningCommand { get; set; }
        public ICommand NavigateToAddOrUpdatePlanningCommand { get; set; }
        public ICommand PlanningDeleteCommand { get; set; }
        public ICommand SearchPlanningCommand { get; set; }

        public ObservableCollection<PlanningViewModel> Plannings { get; private set; }

        public PlanningViewModel SelectedPlanning { get; set; }

        public DateTime? SearchDate { get; set; }

        private void OnNavigationServicePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(NavigationService.CurrentRoute)) return;

            if (NavigationService.CurrentRoute != Routes.Routes.PlanningList) return;

            UpdateEntityViewModelFromNavigationParameter();

            LoadPlannings();
        }

        private void UpdateEntityViewModelFromNavigationParameter()
        {
            if (NavigationService.Parameter is int)
                _inspectionId = (int) NavigationService.Parameter;
            else
                throw new ArgumentNullException(nameof(InspectionVM));
        }

        private void RegisterCommands()
        {
            NavigateToAddPlanningCommand =
                new RelayCommand(() => NavigationService.NavigateTo(Routes.Routes.PlanningAddOrUpdate,
                    _planningViewModelFactory.CreateViewModelForInspection(_inspectionId)));
            NavigateToAddOrUpdatePlanningCommand = new RelayCommand(
                () => NavigationService.NavigateTo(Routes.Routes.PlanningAddOrUpdate, SelectedPlanning),
                () => SelectedPlanning != null);
            PlanningDeleteCommand = new RelayCommand(() =>
            {
                SelectedPlanning.Delete();
                LoadPlannings();
            }, () => SelectedPlanning != null);
            SearchPlanningCommand = new RelayCommand(LoadPlannings);
        }

        private void LoadPlannings()
        {
            using (var planningRepository = _planningRepositoryFactory.CreateRepository())
            {
                var query = planningRepository.GetByInspectionId(_inspectionId);

                if (SearchDate.HasValue)
                    query = query.Where(planning => planning.Date.Equals(SearchDate.Value));

                Plannings = new ObservableCollection<PlanningViewModel>(
                    query.ToList().Select(planning => _planningViewModelFactory.CreateViewModel(planning)));
                RaisePropertyChanged(nameof(Plannings));
            }
        }
    }
}