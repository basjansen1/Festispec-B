using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.NavigationService;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace Festispec.ViewModels.Template
{
    public class TemplateAddViewModel : TemplateAddOrUpdateViewModel
    {
        public ICommand NavigateToAddQuestionCommand { get; set; }

        public TemplateAddViewModel(INavigationService navigationService,
            ITemplateRepositoryFactory repositoryFactory, ITemplateViewModelFactory templateViewModelFactory)
            : base(navigationService, repositoryFactory, templateViewModelFactory)
        {
            RegisterCommands();
        }
        private void RegisterCommands()
        {
          NavigateToAddQuestionCommand = new RelayCommand(() => NavigationService.NavigateTo(Routes.Routes.AddQuestion.Key), () => EntityViewModel != null);
        }
    }
}