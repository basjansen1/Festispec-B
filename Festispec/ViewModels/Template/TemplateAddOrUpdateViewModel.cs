using System.ComponentModel;
using System.Windows.Input;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.NavigationService;
using GalaSoft.MvvmLight.CommandWpf;

namespace Festispec.ViewModels.Template
{
    public class TemplateAddOrUpdateViewModel :
        AddOrUpdateViewModelBase<ITemplateViewModelFactory, TemplateViewModel, ITemplateRepository, Domain.Template>
    {
        private readonly ITemplateQuestionRepositoryFactory _templateQuestionRepositoryFactory;

        public TemplateAddOrUpdateViewModel(INavigationService navigationService,
            ITemplateRepositoryFactory repositoryFactory,
            ITemplateQuestionRepositoryFactory templateQuestionRepositoryFactory,
            ITemplateViewModelFactory templateViewModelFactory)
            : base(navigationService, repositoryFactory, templateViewModelFactory)
        {
            _templateQuestionRepositoryFactory = templateQuestionRepositoryFactory;
            RegisterCommands();
        }

        public ICommand NavigateToQuestionAddCommand { get; set; }
        public ICommand NavigateToQuestionUpdateCommand { get; set; }
        public ICommand QuestionDeleteCommand { get; set; }

        private void RegisterCommands()
        {
            NavigateToQuestionAddCommand =
                new RelayCommand(
                    () => NavigationService.NavigateTo(Routes.Routes.TemplateQuestionAdd.Key, EntityViewModel),
                    () => EntityViewModel != null);
            NavigateToQuestionUpdateCommand = new RelayCommand(
                () => NavigationService.NavigateTo(Routes.Routes.TemplateQuestionAddOrUpdate.Key, EntityViewModel),
                () => EntityViewModel.SelectedQuestion != null);
            QuestionDeleteCommand =
                new RelayCommand(() => EntityViewModel.SelectedQuestion.Delete(),
                    () => EntityViewModel.SelectedQuestion != null);
        }

        public override void OnNavigationServicePropertyChange(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "CurrentPageKey") return;

            if (NavigationService.CurrentPageKey != Routes.Routes.TemplateAddOrUpdate.Key) return;

            UpdateEntityViewModelFromNavigationParameter();
        }

        public override void Save()
        {
            // TODO: Validation

            EntityViewModel.Save();

            GoBack(EntityViewModel);
        }
    }
}