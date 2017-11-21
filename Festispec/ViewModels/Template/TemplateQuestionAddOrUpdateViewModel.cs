using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.NavigationService;

namespace Festispec.ViewModels.Template
{
    public class TemplateQuestionAddOrUpdateViewModel :
        AddOrUpdateViewModelBase
            <ITemplateQuestionViewModelFactory, TemplateQuestionViewModel, ITemplateQuestionRepository, TemplateQuestion
                >
    {
        protected TemplateViewModel TemplateViewModel;

        public TemplateQuestionAddOrUpdateViewModel(INavigationService navigationService,
            ITemplateQuestionRepositoryFactory repositoryFactory, ITemplateQuestionViewModelFactory viewModelFactory,
            IQuestionTypeRepositoryFactory questionTypeRepositoryFactory)
            : base(navigationService, repositoryFactory, viewModelFactory)
        {
            using (var questionTypeRepository = questionTypeRepositoryFactory.CreateRepository())
            {
                QuestionTypes = questionTypeRepository.Get().ToList();
            }
        }

        public IEnumerable<QuestionType> QuestionTypes { get; }

        public override void OnNavigationServicePropertyChange(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "CurrentPageKey") return;

            if (NavigationService.CurrentPageKey != Routes.Routes.TemplateQuestionAddOrUpdate.Key) return;

            UpdateEntityViewModelFromNavigationParameter();
        }

        protected override void UpdateEntityViewModelFromNavigationParameter()
        {
            var templateViewModel = NavigationService.Parameter as TemplateViewModel;
            if (templateViewModel == null) return;

            TemplateViewModel = templateViewModel;

            if (TemplateViewModel.SelectedQuestion != null)
            {
                EntityViewModel = TemplateViewModel.SelectedQuestion;
            }
            else
            {
                EntityViewModel = ViewModelFactory.CreateViewModel();

                EntityViewModel.Template = TemplateViewModel.Entity;
                EntityViewModel.Template_Id = templateViewModel.Id;
            }
        }

        public override void Save()
        {
            //TODO: Validation
            
            GoBack();
        }

        public override void GoBack()
        {
            base.GoBack(TemplateViewModel);
        }
    }
}