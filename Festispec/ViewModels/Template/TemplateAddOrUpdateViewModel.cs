using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.NavigationService;
using Festispec.ViewModels.Factory.Interface;
using GalaSoft.MvvmLight.Command;

namespace Festispec.ViewModels.Template
{
    public class TemplateAddOrUpdateViewModel :
        AddOrUpdateViewModelBase<ITemplateViewModelFactory, TemplateViewModel, Domain.Template>
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
                new RelayCommand(() => NavigationService.NavigateTo(Routes.Routes.AddQuestion, EntityViewModel),
                    () => EntityViewModel != null);
            NavigateToUpdateQuestionCommand = new RelayCommand(
                () => NavigationService.NavigateTo(Routes.Routes.UpdateQuestion, EntityViewModel),
                () => EntityViewModel.SelectedQuestion != null);
            DeleteQuestionCommand =
                new RelayCommand(() => EntityViewModel.SelectedQuestion.Delete(),
                    () => EntityViewModel.SelectedQuestion != null);
        }

        public override void OnNavigationServicePropertyChange(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != nameof(NavigationService.CurrentRoute)) return;

            if (NavigationService.CurrentRoute != Routes.Routes.TemplateAddOrUpdate) return;

            UpdateEntityViewModelFromNavigationParameter();
            UpdateTemplateQuestionsFromNavigationParameter();
        }

        private void UpdateTemplateQuestionsFromNavigationParameter()
        {
            var templateQuestionViewModel = NavigationService.Parameter as TemplateQuestionViewModel;
            if (templateQuestionViewModel == null) return;

            var existing = EntityViewModel.Questions.SingleOrDefault(templateQuestion =>
                templateQuestion.Id == templateQuestionViewModel.Id);
            if (existing == null) EntityViewModel.Questions.Add(templateQuestionViewModel.Entity);
        }

        public override void Save()
        {
            // TODO: Validation
            EntityViewModel.Save();

//            using (var templateQuestionRepository = _templateQuestionRepositoryFactory.CreateRepository())
//            {
//                foreach (var templateQuestion in EntityViewModel.UpdatedEntity.Questions)
//                    templateQuestionRepository.AddOrUpdate(templateQuestion);
//            }

            NavigationService.GoBack(EntityViewModel);
        }
    }
}