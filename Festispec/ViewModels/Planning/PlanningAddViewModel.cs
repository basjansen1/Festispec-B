using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.NavigationService;
using Festispec.ViewModels.Factory.Interface;
using GalaSoft.MvvmLight.CommandWpf;

namespace Festispec.ViewModels.Planning
{
    public class PlanningAddViewModel : PlanningAddOrUpdateViewModel
    {
        public PlanningAddViewModel(INavigationService navigationService, IPlanningRepositoryFactory repositoryFactory,
            IPlanningViewModelFactory viewModelFactory, IInspectorRepositoryFactory inspectorRepositoryFactory) : base(
            navigationService, repositoryFactory, viewModelFactory, inspectorRepositoryFactory)
        {
            EntityViewModel.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(EntityViewModel.Date))
                    LoadInspectors();
            };

            RegisterCommands();

            EntityViewModel.Date = EntityViewModel.Inspection.Start.Date;
            LoadInspectors();
        }

        public string SearchInspectorFirstName { get; set; }
        public string SearchInspectorLastName { get; set; }
        public ICommand SearchInspectorsCommand { get; set; }

        public ObservableCollection<Domain.Inspector> Inspectors { get; set; } =
            new ObservableCollection<Domain.Inspector>();

        private void RegisterCommands()
        {
            SearchInspectorsCommand = new RelayCommand(LoadInspectors);
        }

        private void LoadInspectors()
        {
            EntityViewModel.Inspector = null;
            using (var inspectorRepository = InspectorRepositoryFactory.CreateRepository())
            {
                var query = inspectorRepository.GetAvailableNearby(EntityViewModel.Date,
                    EntityViewModel.Inspection.Location, EntityViewModel.InspectorId);

                if (!string.IsNullOrWhiteSpace(SearchInspectorFirstName))
                    query = query.Where(inspector => inspector.FirstName.Contains(SearchInspectorFirstName));

                if (!string.IsNullOrWhiteSpace(SearchInspectorLastName))
                    query = query.Where(inspector => inspector.LastName.Contains(SearchInspectorLastName));

                // Clear inspectors
                Inspectors.Clear();
                // Fill inspectors with  new values to trigger observablecollection updates.
                foreach (var inspector in query)
                    Inspectors.Add(inspector);
            }

            // Raise property changed to update the UI
            RaisePropertyChanged(nameof(Inspectors));
        }
    }
}