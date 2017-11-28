using System.ComponentModel;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.NavigationService;
using Festispec.ViewModels.Factory.Interface;

namespace Festispec.ViewModels.Template
{
    public class TemplateQuestionAddViewModel :
        TemplateQuestionAddOrUpdateViewModel
    {
        public TemplateQuestionAddViewModel(INavigationService navigationService,
            ITemplateQuestionRepositoryFactory repositoryFactory, ITemplateQuestionViewModelFactory viewModelFactory,
            IQuestionTypeRepositoryFactory questionTypeRepositoryFactory)
            : base(navigationService, repositoryFactory, viewModelFactory, questionTypeRepositoryFactory)
        {
        }

        public override void OnNavigationServicePropertyChange(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "CurrentRoute") return;

            if (NavigationService.CurrentRoute != Routes.Routes.TemplateQuestionAdd) return;

            UpdateEntityViewModelFromNavigationParameter();
        }

        public override void Save()
        {
            //TODO: Validation

            TemplateViewModel.Questions.Add(EntityViewModel);

            GoBack();
        }
    }
}