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

namespace Festispec.ViewModels.Template
{
    public class TemplateListViewModel : NavigatableViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly ITemplateRepositoryFactory _templateRepositoryFactory;
        private readonly ITemplateViewModelFactory _templateViewModelFactory;

        public TemplateListViewModel(INavigationService navigationService,
            ITemplateRepositoryFactory templateRepositoryFactory,
            ITemplateViewModelFactory templateViewModelFactory) : base(navigationService)
        {
            _navigationService = navigationService;
            _templateRepositoryFactory = templateRepositoryFactory;
            _templateViewModelFactory = templateViewModelFactory;

            RegisterCommands();
            LoadTemplates();

            TemplateList = new List<TemplateViewModel>();
            NavigationService.PropertyChanged += OnNavigationServicePropertyChanged;
        }

        public ICommand NavigateToTemplateAddCommand { get; set; }
        public ICommand NavigateToTemplateUpdateCommand { get; set; }
        public ICommand TemplateDeleteCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand DeleteFilterCommand { get; set; }
        public ObservableCollection<TemplateViewModel> Templates { get; private set; }

        public TemplateViewModel SelectedTemplate { get; set; }

        public List<TemplateViewModel> TemplateList;

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
            if (args.PropertyName != nameof(NavigationService.CurrentRoute)) return;

            if (NavigationService.CurrentRoute != Routes.Routes.TemplateList) return;

            LoadTemplates();
        }

        private void RegisterCommands()
        {
            NavigateToTemplateAddCommand =
                new RelayCommand(() => _navigationService.NavigateTo(Routes.Routes.TemplateAddOrUpdate));

            NavigateToTemplateUpdateCommand = new RelayCommand(
                () => _navigationService.NavigateTo(Routes.Routes.TemplateAddOrUpdate, SelectedTemplate),
                () => SelectedTemplate != null);

            TemplateDeleteCommand = new RelayCommand(() =>
            {
                var result = MessageBox.Show("Weet je zeker dat je deze Template wilt verwijderen?", "Waarschuwing", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result != MessageBoxResult.Yes) return;
                SelectedTemplate.Delete();
                LoadTemplates();
            }, () => SelectedTemplate != null);
            SearchCommand = new RelayCommand(SearchTemplates);
            DeleteFilterCommand = new RelayCommand(DeleteFilter);
        }
        public void SearchTemplates()
        {
            if (SearchInput == null) return;

            LoadTemplates();
            TemplateList.Clear();
            Templates.ToList().ForEach(n => TemplateList.Add(n));
            Templates.Clear();

            foreach (var i in TemplateList)
            {
                if (i.Name != null && i.Name.ToLower().Contains(SearchInput.ToLower()) || 
                    i.Description != null && i.Description.ToLower().Contains(SearchInput.ToLower()))
                {
                    Templates.Add(i);
                }
            }
        }
        public void LoadTemplates()
        {
            using (var templateRepository = _templateRepositoryFactory.CreateRepository())
            {
                var query = templateRepository.Get();
                Templates =
                    new ObservableCollection<TemplateViewModel>(
                        query.ToList()
                            .Select(template => _templateViewModelFactory.CreateViewModel(template)));
                RaisePropertyChanged(nameof(Templates));
            }
        }
        private void DeleteFilter()
        {
            LoadTemplates();
            SearchInput = null;
        }
    }
}