using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.Factory.Interface;
using Festispec.NavigationService;
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
            if (args.PropertyName != "CurrentRoute") return;

            if (NavigationService.CurrentRoute != Routes.Routes.InspectorList) return;

            LoadInspectors();
        }

        private void RegisterCommands()
        {
            NavigateToInspectorAddCommand =
                new RelayCommand(() => _navigationService.NavigateTo(Routes.Routes.InspectorAddOrUpdate));
            NavigateToInspectorUpdateCommand = new RelayCommand(
                () => _navigationService.NavigateTo(Routes.Routes.InspectorAddOrUpdate, SelectedInspector),
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
            using (var inspectorRepository = _inspectorRepositoryFactory.CreateRepository())
            {
                Inspectors =
                    new ObservableCollection<InspectorViewModel>(
                        inspectorRepository.Get()
                            .Where(inspector =>
                                (!inspector.HiredTo.HasValue || inspector.HiredTo.Value > today)
                                && inspector.Username.Contains(SearchUsername)
                                && inspector.Email.Contains(SearchEmail)
                                && inspector.Role_Role.Equals("Inspecteur"))
                            .ToList()
                            .Select(Inspector => _inspectorViewModelFactory.CreateViewModel(Inspector)));
                RaisePropertyChanged(nameof(Inspectors));
            }
        }
    }
}