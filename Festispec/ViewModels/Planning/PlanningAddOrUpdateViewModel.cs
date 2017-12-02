using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
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

        public IEnumerable<Domain.Inspector> Inspectors { get; set; }

        public override void OnNavigationServicePropertyChange(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != nameof(NavigationService.CurrentRoute)) return;

            if (NavigationService.CurrentRoute != Routes.Routes.PlanningAddOrUpdate) return;

            UpdateEntityViewModelFromNavigationParameter();
        }

        private void RegisterCommands()
        {
            SearchInspectors = new RelayCommand(LoadInspectors);
        }

        private void LoadInspectors()
        {
            // Reset the selected inspector
//            EntityViewModel.Inspector = null;

            using (var inspectorRepository = _inspectorRepositoryFactory.CreateRepository())
            {
                var query = inspectorRepository.GetAvailableNearby(EntityViewModel.Date,
                    EntityViewModel.Inspection.Location);

                // TODO: Filter

                Inspectors = query.ToList();
            }

            // Raise property changed to update the UI
            RaisePropertyChanged(nameof(Inspectors));
        }

        public override void GoBack()
        {
            base.GoBack(EntityViewModel.InspectionId);
        }
    }
}