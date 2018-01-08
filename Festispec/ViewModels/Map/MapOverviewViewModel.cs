using System.Collections.ObjectModel;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.NavigationService;

namespace Festispec.ViewModels.Map
{
    public class MapOverviewViewModel : NavigatableViewModelBase
    {
        private readonly ICustomerRepositoryFactory _customerRepositoryFactory;
        private readonly IInspectionRepositoryFactory _inspectionRepositoryFactory;
        private readonly IInspectorRepositoryFactory _inspectorRepositoryFactory;

        public MapOverviewViewModel(INavigationService navigationService,
            IInspectorRepositoryFactory inspectorRepositoryFactory,
            IInspectionRepositoryFactory inspectionRepositoryFactory,
            ICustomerRepositoryFactory customerRepositoryFactory) : base(navigationService)
        {
            _inspectorRepositoryFactory = inspectorRepositoryFactory;
            _inspectionRepositoryFactory = inspectionRepositoryFactory;
            _customerRepositoryFactory = customerRepositoryFactory;

            LoadOverview();
        }

        public ObservableCollection<Domain.Inspector> Inspectors { get; set; } =
            new ObservableCollection<Domain.Inspector>();

        public ObservableCollection<Domain.Inspection> Inspections { get; set; } =
            new ObservableCollection<Domain.Inspection>();

        public ObservableCollection<Domain.Customer> Customers { get; set; } =
            new ObservableCollection<Domain.Customer>();

        private void LoadOverview()
        {
            LoadInspectors();
            LoadInspections();
            LoadCustomers();
        }

        private void LoadInspectors()
        {
            using (var inspectorRepository = _inspectorRepositoryFactory.CreateRepository())
            {
                var query = inspectorRepository.Get();

                // Clear inspectors
                Inspectors.Clear();
                // Fill inspectors with  new values to trigger observablecollection updates.
                foreach (var inspector in query)
                    Inspectors.Add(inspector);
            }

            // Raise property changed to update the UI
            RaisePropertyChanged(nameof(Inspectors));
        }

        private void LoadInspections()
        {
            using (var inspectionRepository = _inspectionRepositoryFactory.CreateRepository())
            {
                var query = inspectionRepository.Get();

                // Clear inspections
                Inspections.Clear();
                // Fill inspections with  new values to trigger observablecollection updates.
                foreach (var inspection in query)
                    Inspections.Add(inspection);
            }

            // Raise property changed to update the UI
            RaisePropertyChanged(nameof(Inspections));
        }

        private void LoadCustomers()
        {
            using (var customerRepository = _customerRepositoryFactory.CreateRepository())
            {
                var query = customerRepository.Get();

                // Clear customers
                Customers.Clear();
                // Fill customers with  new values to trigger observablecollection updates.
                foreach (var customer in query)
                    Customers.Add(customer);
            }

            // Raise property changed to update the UI
            RaisePropertyChanged(nameof(Customers));
        }
    }
}