using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.Factory.Interface;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using Festispec.NavigationService;

namespace Festispec.ViewModels.Regulations
{
    public class RegulationsListViewModel : NavigatableViewModelBase
    {
        public RegulationsListViewModel(INavigationService navigationService,
            IEmployeeRepositoryFactory employeeRepositoryFactory,
            IEmployeeViewModelFactory employeeViewModelFactory) : base(navigationService)
        {
            _navigationService = navigationService;
            _regulationsRepositoryFactory = regulationsRepositoryFactory;
            _regulationsViewModelFactory = regulationsViewModelFactory;

            RegisterCommands();
            LoadEmployees();

            NavigationService.PropertyChanged += OnNavigationServicePropertyChanged;
        }
        public ICommand NavigateToRegulationsAddCommand { get; set; }
        public ICommand NavigateToRegulationsUpdateCommand { get; set; }
        public ICommand RegulationsDeleteCommand { get; set; }
        public ICommand SearchCommand { get; set; }

        public ObservableCollection<RegulationsViewModel> Regulations { get; private set; }

        public RegulationsViewModel SelectedRegulations { get; set; }

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
                Regulations =
                    new ObservableCollection<RegulationsViewModel>(
                        RegulationsRepository.Get()
                            .Where(Regulations =>
                                Regulations.Name.Contains(SearchName)
                                && Regulations.Municipality.Contains(SearchMunicipality)
                            .ToList()
                            .Select(Employee => _regulationsViewModelFactory.CreateViewModel(Regulations)));
                RaisePropertyChanged(nameof(Regulations));
            }
        }
    }
}
