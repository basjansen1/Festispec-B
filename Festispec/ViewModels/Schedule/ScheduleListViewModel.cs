using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.Factory.Interface;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using Festispec.NavigationService;

namespace Festispec.ViewModels.Schedule
{
    public class ScheduleListViewModel : NavigatableViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IScheduleRepositoryFactory _employeeRepositoryFactory;
        private readonly IScheduleViewModelFactory _employeeViewModelFactory;

        public ScheduleListViewModel(INavigationService navigationService,
            IScheduleRepositoryFactory employeeRepositoryFactory,
            IScheduleViewModelFactory employeeViewModelFactory) : base(navigationService)
        {
            _navigationService = navigationService;
            _employeeRepositoryFactory = employeeRepositoryFactory;
            _employeeViewModelFactory = employeeViewModelFactory;

            RegisterCommands();
            LoadSchedules();

            NavigationService.PropertyChanged += OnNavigationServicePropertyChanged;
        }

        public ICommand NavigateToScheduleAddCommand { get; set; }
        public ICommand NavigateToScheduleUpdateCommand { get; set; }
        public ICommand NavigateToScheduleViewCommand { get; set; }
        public ICommand ScheduleDeleteCommand { get; set; }
        public ICommand SearchCommand { get; set; }

        public ObservableCollection<ScheduleViewModel> Schedules { get; private set; }

        public ScheduleViewModel SelectedSchedule { get; set; }

        public string SearchUsername { get; set; } = "";
        public string SearchEmail { get; set; } = "";

        private void OnNavigationServicePropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "CurrentRoute") return;

            if (NavigationService.CurrentRoute != Routes.Routes.ScheduleList) return;

            LoadSchedules();
        }

        private void RegisterCommands()
        {
            NavigateToScheduleUpdateCommand = new RelayCommand(
                () => _navigationService.NavigateTo(Routes.Routes.ScheduleUpdate, SelectedSchedule),
                () => SelectedSchedule != null);
            NavigateToScheduleViewCommand = new RelayCommand(
                 () => _navigationService.NavigateTo(Routes.Routes.ScheduleView, SelectedSchedule),
                 () => SelectedSchedule != null);
            SearchCommand = new RelayCommand(LoadSchedules);
        }

        private void LoadSchedules()
        {
            DateTime today = DateTime.Today;
            using (var ScheduleRepository = _employeeRepositoryFactory.CreateRepository())
            {
                Schedules =
                    new ObservableCollection<ScheduleViewModel>(
                        ScheduleRepository.Get().GroupBy(Schedule => Schedule.Inspector_Id)
                            .Select(Schedule => Schedule.FirstOrDefault())
                            .OrderBy(Schedule => Schedule.NotAvailableTo)
                            .ToList()
                            .Select(Schedule => _employeeViewModelFactory.CreateViewModel(Schedule)));
                RaisePropertyChanged(nameof(Schedules));
            }
        }
    }
}