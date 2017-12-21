using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.Factory.Interface;
using Festispec.NavigationService;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;

namespace Festispec.ViewModels.Inspector
{
    public class InspectorListViewModel : NavigatableViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IInspectorRepositoryFactory _inspectorRepositoryFactory;
        private readonly IInspectorViewModelFactory _inspectorViewModelFactory;
        private readonly List<InspectorViewModel> _inspectorList;
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
            _inspectorList = new List<InspectorViewModel>();
        }

        public ICommand NavigateToInspectorAddCommand { get; set; }
        public ICommand NavigateToInspectorUpdateCommand { get; set; }
        public ICommand NavigateToInspectorScheduleCommand { get; set; }
        public ICommand InspectorDeleteCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand DeleteFilterCommand { get; set; }
        public ObservableCollection<InspectorViewModel> Inspectors { get; private set; }

        public InspectorViewModel SelectedInspector { get; set; }

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
        private void OnNavigationServicePropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "CurrentRoute") return;

            if (NavigationService.CurrentRoute != Routes.Routes.InspectorList) return;

            LoadInspectors();
        }

        private void RegisterCommands()
        {
            NavigateToInspectorScheduleCommand =
                new RelayCommand(() => _navigationService.NavigateTo(Routes.Routes.InspectorSchedule, SelectedInspector),
                () => SelectedInspector != null && _navigationService.HasAccess(Routes.Routes.InspectorSchedule));
            NavigateToInspectorAddCommand =
                new RelayCommand(() => _navigationService.NavigateTo(Routes.Routes.InspectorAddOrUpdate));
            NavigateToInspectorUpdateCommand = new RelayCommand(
                () => _navigationService.NavigateTo(Routes.Routes.InspectorAddOrUpdate, SelectedInspector),
                () => SelectedInspector != null);
            InspectorDeleteCommand = new RelayCommand(() => {
                SelectedInspector.Delete();
                LoadInspectors();
            }, () => SelectedInspector != null);
            SearchCommand = new RelayCommand(SearchInspectors);
            DeleteFilterCommand = new RelayCommand(DeleteFilter);
        }

        private void SearchInspectors()
        {
            if (SearchInput == null) return;
            LoadInspectors();
            _inspectorList.Clear();
            Inspectors.ToList().ForEach(n => _inspectorList.Add(n));
            Inspectors.Clear();

            foreach (var i in _inspectorList)
            {
                if (i.Username.ToLower().Contains(SearchInput.ToLower()) || 
                    i.Email.ToLower().Contains(SearchInput.ToLower()) ||
                    i.Manager.Username.ToLower().Contains(SearchInput.ToLower()))
                {
                    Inspectors.Add(i);
                }
            }
        }

        private void DeleteFilter()
        {
            LoadInspectors();
            SearchInput = null;
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
                                && inspector.Role_Role.Equals("Inspecteur"))
                            .ToList()
                            .Select(Inspector => _inspectorViewModelFactory.CreateViewModel(Inspector)));
                RaisePropertyChanged(nameof(Inspectors));
            }
        }
    }
}