using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using Festispec.NavigationService;
using Festispec.ViewModels.Factory.Interface;
using GalaSoft.MvvmLight.CommandWpf;

namespace Festispec.ViewModels.Planning
{
    public class PlanningAddOrUpdateViewModel :
        AddOrUpdateViewModelBase<IPlanningViewModelFactory, PlanningViewModel, IPlanningRepository, Domain.Planning>
    {
        private readonly IInspectorRepositoryFactory _inspectorRepositoryFactory;

        public PlanningAddOrUpdateViewModel(INavigationService navigationService,
            IPlanningRepositoryFactory repositoryFactory,
            IPlanningViewModelFactory viewModelFactory, IInspectorRepositoryFactory inspectorRepositoryFactory) : base(
            navigationService, repositoryFactory, viewModelFactory)
        {
            _inspectorRepositoryFactory = inspectorRepositoryFactory;

            RegisterCommands();
        }

        public ICommand SearchInspectors { get; set; }

        public ObservableCollection<Domain.Inspector> Inspectors { get; set; } = new ObservableCollection<Domain.Inspector>();

        public override void OnNavigationServicePropertyChange(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != nameof(NavigationService.CurrentRoute)) return;

            if (NavigationService.CurrentRoute != Routes.Routes.PlanningAdd && NavigationService.CurrentRoute != Routes.Routes.PlanningUpdate) return;

            UpdateEntityViewModelFromNavigationParameter();
        }

        private void RegisterCommands()
        {
            SearchInspectors = new RelayCommand(LoadInspectors);
        }

        private void LoadInspectors()
        {
            using (var inspectorRepository = _inspectorRepositoryFactory.CreateRepository())
            {
                var query = inspectorRepository.GetAvailableNearby(EntityViewModel.Date,
                    EntityViewModel.Inspection.Location, EntityViewModel.InspectorId);

                // TODO: Filter

                // Clear inspectors
                Inspectors.Clear();
                // Fill inspectors with  new values to trigger observablecollection updates.
                foreach (var inspector in query)
                    Inspectors.Add(inspector);
            }

            // Raise property changed to update the UI
            RaisePropertyChanged(nameof(Inspectors));
        }

        public override void Save()
        {
            // TODO: Validation

            var saved = EntityViewModel.Save();

            if(saved) GoBack();
        }

        public override void GoBack()
        {
            base.GoBack(EntityViewModel.Inspection);
        }
    }
}