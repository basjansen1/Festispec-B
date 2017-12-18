﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
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
        private readonly IRegulationRepositoryFactory _regulationRepositoryFactory;
        private readonly IRegulationViewModelFactory _regulationViewModelFactory;

        public RegulationListViewModel(INavigationService navigationService,
            IRegulationRepositoryFactory regulationRepositoryFactory,
            IRegulationViewModelFactory regulationViewModelFactory) : base(navigationService)
        {
            _navigationService = navigationService;
            _regulationRepositoryFactory = regulationRepositoryFactory;
            _regulationViewModelFactory = regulationViewModelFactory;

            RegisterCommands();
            LoadRegulations();

            NavigationService.PropertyChanged += OnNavigationServicePropertyChanged;
        }
        public ICommand NavigateToRegulationAddCommand { get; set; }
        public ICommand NavigateToRegulationUpdateCommand { get; set; }
        public ICommand RegulationDeleteCommand { get; set; }
        public ICommand SearchCommand { get; set; }

        public ObservableCollection<RegulationViewModel> Regulation { get; private set; }

        public RegulationViewModel SelectedRegulation { get; set; }

        public string SearchName { get; set; } = "";
        public string SearchMunicipality { get; set; } = "";

        private void OnNavigationServicePropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "CurrentRoute") return;

            if (NavigationService.CurrentRoute != Routes.Routes.RegulationList) return;

            LoadRegulations();
        }
        private void RegisterCommands()
        {
            NavigateToRegulationAddCommand =
                new RelayCommand(() => _navigationService.NavigateTo(Routes.Routes.RegulationAddOrUpdate));
            NavigateToRegulationUpdateCommand = new RelayCommand(
                () => _navigationService.NavigateTo(Routes.Routes.RegulationAddOrUpdate, SelectedRegulation),
                () => SelectedRegulation != null);
            RegulationDeleteCommand = new RelayCommand(() => {
                var result = MessageBox.Show("Weet je zeker dat je deze regel wilt verwijderen?", "Waarschuwing", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result != MessageBoxResult.Yes) return;
                SelectedRegulation.Delete();
                LoadRegulations();
            }, () => SelectedRegulation != null);
            SearchCommand = new RelayCommand(LoadRegulations);
        }
        private void LoadRegulations()
        {
            using (var RegulationsRepository = _regulationRepositoryFactory.CreateRepository())
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

                Regulation =
                    new ObservableCollection<RegulationViewModel>(
                        query.ToList()
                            .Select(regulation => _regulationViewModelFactory.CreateViewModel(regulation)));
                RaisePropertyChanged(nameof(Regulation));
            }
        }
    }
}
