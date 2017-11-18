using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.NavigationService;
using GalaSoft.MvvmLight.Command;

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

        public ICommand NavigateToAddQuestionCommand { get; set; }
        public ICommand NavigateToUpdateQuestionCommand { get; set; }
        public ICommand DeleteQuestionCommand { get; set; }

        private void RegisterCommands()
        {
            NavigateToAddQuestionCommand =
                new RelayCommand(() => NavigationService.NavigateTo(Routes.Routes.AddQuestion.Key, EntityViewModel),
                    () => EntityViewModel != null);
            NavigateToUpdateQuestionCommand = new RelayCommand(
                () => NavigationService.NavigateTo(Routes.Routes.UpdateQuestion.Key, EntityViewModel),
                () => EntityViewModel.SelectedQuestion != null);
            DeleteQuestionCommand =
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