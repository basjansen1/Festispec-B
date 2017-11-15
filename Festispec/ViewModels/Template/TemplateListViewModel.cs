using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.NavigationService;
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
            if (args.PropertyName != "CurrentPageKey") return;

            if (NavigationService.CurrentPageKey != Routes.Routes.TemplateList.Key) return;

            UpdateTemplatesFromNavigationParameter();
        }

        private void UpdateTemplatesFromNavigationParameter()
        {
            var templateViewModel = NavigationService.Parameter as TemplateViewModel;
            if (templateViewModel == null) return;

            var existing = Templates.SingleOrDefault(template => template.Id == templateViewModel.Id);
            if (existing == null)
            {
                Templates.Add(templateViewModel);
            }
            else
            {
                var index = Templates.IndexOf(existing);
                Templates.RemoveAt(index);
                Templates.Insert(index, templateViewModel);
            }
        }

        private void RegisterCommands()
        {
            NavigateToTemplateAddCommand =
                new RelayCommand(() => _navigationService.NavigateTo(Routes.Routes.TemplateAddOrUpdate.Key));
            NavigateToTemplateUpdateCommand = new RelayCommand(
                () => _navigationService.NavigateTo(Routes.Routes.TemplateAddOrUpdate.Key, SelectedTemplate),
                () => SelectedTemplate != null);
            TemplateDeleteCommand = new RelayCommand(() => SelectedTemplate.Delete(), () => SelectedTemplate != null);
            SearchCommand = new RelayCommand(LoadTemplates);
        }

        private void LoadTemplates()
        {
            using (var templateRepository = _templateRepositoryFactory.CreateRepository())
            {
                Templates =
                    new ObservableCollection<TemplateViewModel>(
                        templateRepository.Get()
                            .Where(template =>
                                template.Name.Contains(SearchName)
                                && template.Description.Contains(SearchDescription))
                            .ToList()
                            .Select(template => _templateViewModelFactory.CreateViewModel(template)));
                RaisePropertyChanged(nameof(Templates));
            }
        }
    }
}