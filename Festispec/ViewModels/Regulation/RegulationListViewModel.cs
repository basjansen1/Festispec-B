using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private readonly List<RegulationViewModel> _regulationList;
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
            _regulationList = new List<RegulationViewModel>();
        }
        public ICommand NavigateToRegulationAddCommand { get; set; }
        public ICommand NavigateToRegulationUpdateCommand { get; set; }
        public ICommand RegulationDeleteCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand DeleteFilterCommand { get; set; }
        public ObservableCollection<RegulationViewModel> Regulations { get; private set; }

        public RegulationViewModel SelectedRegulation { get; set; }

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

            SearchCommand = new RelayCommand(SearchRegulations);
            DeleteFilterCommand = new RelayCommand(DeleteFilter);
        }

        private void LoadRegulations()
        {
            using (var regulationsRepository = _regulationRepositoryFactory.CreateRepository())
            {
                var query = regulationsRepository.Get();         
                Regulations =
                    new ObservableCollection<RegulationViewModel>(
                        query.ToList()
                            .Select(regulation => _regulationViewModelFactory.CreateViewModel(regulation)));
                RaisePropertyChanged(nameof(Regulation));
            }
        }
        private void SearchRegulations()
        {
            if (SearchInput == null) return;

            LoadRegulations();
            _regulationList.Clear();
            Regulations.ToList().ForEach(n => _regulationList.Add(n));
            Regulations.Clear();

            foreach (var i in _regulationList)
            {
                if (i.Name.ToLower().Contains(SearchInput.ToLower()) ||
                    i.Municipality != null && i.Municipality.ToLower().Contains(SearchInput.ToLower()) ||
                    i.Description.ToLower().Contains(SearchInput.ToLower()))
                {
                    Regulations.Add(i);
                }
            }
            RaisePropertyChanged(nameof(Regulations));
        }

        private void DeleteFilter()
        {
            LoadRegulations();
            SearchInput = "";
        }
    }
}
