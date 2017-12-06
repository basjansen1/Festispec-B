using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.NavigationService;
using Festispec.ViewModels.Factory.Interface;
using GalaSoft.MvvmLight.CommandWpf;

namespace Festispec.ViewModels.Regulation
{
    public class RegulationListViewModel : NavigatableViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IRegulationRepositoryFactory _regulationsRepositoryFactory;
        private readonly IRegulationsViewModelFactory _regulationsViewModelFactory;

        public RegulationListViewModel(INavigationService navigationService,
            IRegulationRepositoryFactory regulationsRepositoryFactory,
            IRegulationsViewModelFactory regulationsViewModelFactory) : base(navigationService)
        {
            _navigationService = navigationService;
            _regulationsRepositoryFactory = regulationsRepositoryFactory;
            _regulationsViewModelFactory = regulationsViewModelFactory;

            RegisterCommands();
            LoadRegulations();

            NavigationService.PropertyChanged += OnNavigationServicePropertyChanged;
        }
        public ICommand NavigateToRegulationsAddCommand { get; set; }
        public ICommand NavigateToRegulationsUpdateCommand { get; set; }
        public ICommand RegulationsDeleteCommand { get; set; }
        public ICommand SearchCommand { get; set; }

        public ObservableCollection<RegulationViewModel> Regulations { get; private set; }

        public RegulationViewModel SelectedRegulations { get; set; }

        public string SearchName { get; set; } = "";
        public string SearchMunicipality { get; set; } = "";

        private void OnNavigationServicePropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "CurrentRoute") return;

            if (NavigationService.CurrentRoute != Routes.Routes.RegulationsList) return;

            LoadRegulations();
        }
        private void RegisterCommands()
        {
            NavigateToRegulationsAddCommand =
                new RelayCommand(() => _navigationService.NavigateTo(Routes.Routes.RegulationsAddOrUpdate));
            NavigateToRegulationsUpdateCommand = new RelayCommand(
                () => _navigationService.NavigateTo(Routes.Routes.RegulationsAddOrUpdate, SelectedRegulations),
                () => SelectedRegulations != null);
            RegulationsDeleteCommand = new RelayCommand(() => {
                SelectedRegulations.Delete();
                LoadRegulations();
            }, () => SelectedRegulations != null);
            SearchCommand = new RelayCommand(LoadRegulations);
        }
        private void LoadRegulations()
        {
            using (var RegulationsRepository = _regulationsRepositoryFactory.CreateRepository())
            {
                var query = RegulationsRepository.Get();

                if (!string.IsNullOrWhiteSpace(SearchName))
                {
                    query = query.Where(regulation => regulation.Name.Contains(SearchName));
                }
                if (!string.IsNullOrWhiteSpace(SearchMunicipality))
                {
                    query = query.Where(regulation => regulation.Municipality.Contains(SearchMunicipality));
                }

                Regulations =
                    new ObservableCollection<RegulationViewModel>(
                        query.ToList()
                            .Select(regulation => _regulationsViewModelFactory.CreateViewModel(regulation)));
                RaisePropertyChanged(nameof(Regulations));
            }
        }
    }
}
