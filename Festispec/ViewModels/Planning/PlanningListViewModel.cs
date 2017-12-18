using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.NavigationService;
using Festispec.ViewModels.Factory.Interface;
using GalaSoft.MvvmLight.CommandWpf;

namespace Festispec.ViewModels.Planning
{
    public class PlanningListViewModel : NavigatableViewModelBase
    {
        private readonly IPlanningRepositoryFactory _planningRepositoryFactory;
        private readonly IPlanningViewModelFactory _planningViewModelFactory;

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

        public Domain.Inspection Inspection { get; private set; }

        public ICommand NavigateToAddPlanningCommand { get; set; }
        public ICommand NavigateToAddOrUpdatePlanningCommand { get; set; }
        public ICommand PlanningDeleteCommand { get; set; }
        public ICommand SearchPlanningCommand { get; set; }
        public ICommand NavigateBackCommand { get; set; }

        public ObservableCollection<PlanningViewModel> Plannings { get; } =
            new ObservableCollection<PlanningViewModel>();

        public PlanningViewModel SelectedPlanning { get; set; }

        public string SearchInspectorFirstName { get; set; }
        public string SearchInspectorLastName { get; set; }
        public DateTime SearchDate { get; set; }


        private void OnNavigationServicePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(NavigationService.CurrentRoute)) return;

            if (NavigationService.CurrentRoute != Routes.Routes.PlanningList) return;

            UpdateEntityViewModelFromNavigationParameter();

            LoadPlannings();
        }

        private void UpdateEntityViewModelFromNavigationParameter()
        {
            var parameter = NavigationService.Parameter as Domain.Inspection;
            if (parameter != null)
                Inspection = parameter;
            else
                throw new ArgumentNullException(nameof(Domain.Inspection));

            SearchDate = Inspection.Start.Date;
        }

        private void RegisterCommands()
        {
            NavigateToAddPlanningCommand =
                new RelayCommand(() => NavigationService.NavigateTo(Routes.Routes.PlanningAdd,
                    _planningViewModelFactory.CreateViewModelForInspection(Inspection)));
            NavigateToAddOrUpdatePlanningCommand = new RelayCommand(
                () => NavigationService.NavigateTo(Routes.Routes.PlanningUpdate, SelectedPlanning),
                () => SelectedPlanning != null);
            PlanningDeleteCommand = new RelayCommand(() =>
            {
                var result = MessageBox.Show("Weet je zeker dat je deze planning wilt verwijderen?", "Waarschuwing", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result != MessageBoxResult.Yes) return;
                SelectedPlanning.Delete();
                LoadPlannings();
            }, () => SelectedPlanning != null);
            SearchPlanningCommand = new RelayCommand(LoadPlannings);
            NavigateBackCommand = new RelayCommand(GoBack);
        }

        private void LoadPlannings()
        {
            using (var planningRepository = _planningRepositoryFactory.CreateRepository())
            {
                var query = planningRepository.GetByInspectionId(Inspection.Id);

                query = query.Where(planning => planning.Date.Equals(SearchDate));

                if (!string.IsNullOrWhiteSpace(SearchInspectorFirstName))
                    query = query.Where(planning => planning.Inspector.FirstName.Contains(SearchInspectorFirstName));

                if (!string.IsNullOrWhiteSpace(SearchInspectorLastName))
                    query = query.Where(planning => planning.Inspector.LastName.Contains(SearchInspectorLastName));

                var plannings = query.ToList().Select(planning => _planningViewModelFactory.CreateViewModel(planning));

                // Clear plannings
                Plannings.Clear();
                // Fill plannings with  new values to trigger observablecollection updates.
                foreach (var planning in plannings)
                    Plannings.Add(planning);
            }
        }

        private void GoBack()
        {
            NavigationService.GoBack();
        }
    }
}