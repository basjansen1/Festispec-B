using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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

            NavigationService.PropertyChanged += OnNavigationServicePropertyChanged;
        }

        public ICommand NavigateToTemplateAddCommand { get; set; }
        public ICommand NavigateToTemplateUpdateCommand { get; set; }
        public ICommand TemplateDeleteCommand { get; set; }
        public ICommand SearchCommand { get; set; }

        public ObservableCollection<TemplateViewModel> Templates { get; private set; }

        public TemplateViewModel SelectedTemplate { get; set; }

        public string SearchName { get; set; } = "";
        public string SearchDescription { get; set; } = "";

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
                SelectedTemplate.Delete();
                LoadTemplates();
            }, () => SelectedTemplate != null);
            SearchCommand = new RelayCommand(LoadTemplates);
        }

        private void LoadTemplates()
        {
            using (var templateRepository = _templateRepositoryFactory.CreateRepository())
            {
                var query = templateRepository.Get();

                if (!string.IsNullOrWhiteSpace(SearchName))
                {
                    query = query.Where(template => template.Name.Contains(SearchName));
                }
                if (!string.IsNullOrWhiteSpace(SearchDescription))
                {
                    query = query.Where(template => template.Description.Contains(SearchDescription));
                }

                Templates =
                    new ObservableCollection<TemplateViewModel>(
                        query.ToList()
                            .Select(template => _templateViewModelFactory.CreateViewModel(template)));
                RaisePropertyChanged(nameof(Templates));
            }
        }
    }
}