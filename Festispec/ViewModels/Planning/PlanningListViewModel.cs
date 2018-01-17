using System;
using System.Collections.Generic;
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
        private readonly List<PlanningViewModel> _plannngList;
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

            _plannngList = new List<PlanningViewModel>();
        }
        public string SearchInput
        {
            get
            {
                return _searchInput;
            }
            set
            {
                _searchInput = value;
                RaisePropertyChanged("SearchInput");
            }
        }

        private string _searchInput;

        public Domain.Inspection Inspection { get; private set; }

        public ICommand NavigateToAddPlanningCommand { get; set; }
        public ICommand NavigateToAddOrUpdatePlanningCommand { get; set; }
        public ICommand PlanningDeleteCommand { get; set; }
        public ICommand SearchPlanningCommand { get; set; }
        public ICommand NavigateBackCommand { get; set; }
        public ICommand DeleteFilterCommand { get; set; }
        public ObservableCollection<PlanningViewModel> Plannings { get; } =
            new ObservableCollection<PlanningViewModel>();

        public PlanningViewModel SelectedPlanning { get; set; }

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
                    _planningViewModelFactory.CreateViewModelForInspection(Inspection)), () => NavigationService.CanAndHasAccess(Routes.Routes.PlanningAdd));
            NavigateToAddOrUpdatePlanningCommand = new RelayCommand(
                () => NavigationService.NavigateTo(Routes.Routes.PlanningUpdate, SelectedPlanning),
                () => SelectedPlanning != null && NavigationService.CanAndHasAccess(Routes.Routes.PlanningUpdate));
            PlanningDeleteCommand = new RelayCommand(() =>
            {
                var result = MessageBox.Show("Weet je zeker dat je deze planning wilt verwijderen?", "Waarschuwing", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result != MessageBoxResult.Yes) return;
                SelectedPlanning.Delete();
                LoadPlannings();
            }, () => SelectedPlanning != null);
            SearchPlanningCommand = new RelayCommand(SearchPlannings);
            NavigateBackCommand = new RelayCommand(GoBack);
            DeleteFilterCommand = new RelayCommand(DeleteFilter);
        }

        public void SearchPlannings()
        {
            if (SearchInput == null) return;
            LoadPlannings();
            _plannngList.Clear();
            Plannings.ToList().ForEach(n => _plannngList.Add(n));
            Plannings.Clear();

            foreach (var i in _plannngList)
            {
                if (i.Inspector.Username != null && i.Inspector.Username.ToLower().Contains(SearchInput.ToLower()) ||
                    i.Inspector.LastName != null && i.Inspector.LastName.ToLower().Contains(SearchInput.ToLower()))
                {
                    Plannings.Add(i);
                }
            }
        }
        private void LoadPlannings()
        {
            using (var planningRepository = _planningRepositoryFactory.CreateRepository())
            {
                var query = planningRepository.GetByInspectionId(Inspection.Id);
                var plannings = query.ToList().Select(planning => _planningViewModelFactory.CreateViewModel(planning));

                // Clear plannings
                Plannings.Clear();
                // Fill plannings with  new values to trigger observablecollection updates.
                foreach (var planning in plannings)
                    Plannings.Add(planning);
            }
        }

        private void DeleteFilter()
        {
            LoadPlannings();
            SearchInput = null;
        }

        private void GoBack()
        {
            NavigationService.GoBack();
        }
    }
}