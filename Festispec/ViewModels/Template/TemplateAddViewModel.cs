using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.NavigationService;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace Festispec.ViewModels.Template
{
    public class TemplateAddViewModel : TemplateAddOrUpdateViewModel
    {
        public ICommand NavigateToAddQuestionCommand { get; set; }
        public ICommand NavigateToUpdateQuestionCommand { get; set; }
        public ICommand DeleteQuestionCommand { get; set; }

        public TemplateAddViewModel(INavigationService navigationService,
            ITemplateRepositoryFactory repositoryFactory, ITemplateQuestionRepositoryFactory templateQuestionRepositoryFactory, ITemplateViewModelFactory templateViewModelFactory)
            : base(navigationService, repositoryFactory, templateQuestionRepositoryFactory, templateViewModelFactory)
        {
            RegisterCommands();
        }

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
    }
}