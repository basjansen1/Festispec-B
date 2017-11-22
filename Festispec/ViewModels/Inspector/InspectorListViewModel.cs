﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.NavigationService;
using GalaSoft.MvvmLight.CommandWpf;
using System;

namespace Festispec.ViewModels.Inspector
{
    public class InspectorListViewModel : NavigatableViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IInspectorRepositoryFactory _inspectorRepositoryFactory;
        private readonly IInspectorViewModelFactory _inspectorViewModelFactory;

        public InspectorListViewModel(INavigationService navigationService,
            IInspectorRepositoryFactory inspectorRepositoryFactory,
            IInspectorViewModelFactory inspectorViewModelFactory) : base(navigationService)
        {
            _navigationService = navigationService;
            _inspectorRepositoryFactory = inspectorRepositoryFactory;
            _inspectorViewModelFactory = inspectorViewModelFactory;

            RegisterCommands();
            LoadInspectors();

            NavigationService.PropertyChanged += OnNavigationServicePropertyChanged;
        }

        public ICommand NavigateToInspectorAddCommand { get; set; }
        public ICommand NavigateToInspectorUpdateCommand { get; set; }
        public ICommand InspectorDeleteCommand { get; set; }
        public ICommand SearchCommand { get; set; }

        public ObservableCollection<InspectorViewModel> Inspectors { get; private set; }

        public InspectorViewModel SelectedInspector { get; set; }

        public string SearchUsername { get; set; } = "";
        public string SearchEmail { get; set; } = "";

        private void OnNavigationServicePropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "CurrentPageKey") return;

            if (NavigationService.CurrentPageKey != Routes.Routes.InspectorList.Key) return;

            LoadInspectors();
        }

        private void RegisterCommands()
        {
            NavigateToInspectorAddCommand =
                new RelayCommand(() => _navigationService.NavigateTo(Routes.Routes.InspectorAddOrUpdate.Key));
            NavigateToInspectorUpdateCommand = new RelayCommand(
                () => _navigationService.NavigateTo(Routes.Routes.InspectorAddOrUpdate.Key, SelectedInspector),
                () => SelectedInspector != null);
            InspectorDeleteCommand = new RelayCommand(() => {
                SelectedInspector.Delete();
                LoadInspectors();
            }, () => SelectedInspector != null);
            SearchCommand = new RelayCommand(LoadInspectors);
        }

        private void LoadInspectors()
        {
            DateTime today = DateTime.Today;
            using (var InspectorRepository = _inspectorRepositoryFactory.CreateRepository())
            {
                Inspectors =
                    new ObservableCollection<InspectorViewModel>(
                        InspectorRepository.Get()
                            .Where(Inspector =>
                                (Inspector.HiredTo.HasValue ? Inspector.HiredTo.Value > today : true)
                                && Inspector.Username.Contains(SearchUsername)
                                && Inspector.Email.Contains(SearchEmail)
                                && Inspector.Role_Role.Equals("Inspecteur"))
                            .ToList()
                            .Select(Inspector => _inspectorViewModelFactory.CreateViewModel(Inspector)));
                RaisePropertyChanged(nameof(Inspectors));
            }
        }
    }
}