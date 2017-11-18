using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.NavigationService;

namespace Festispec.ViewModels.Template
{
    public class AddQuestionViewModel :
        AddOrUpdateViewModelBase<ITemplateQuestionViewModelFactory, TemplateQuestionViewModel, ITemplateQuestionRepository, TemplateQuestion>
    {
        public AddQuestionViewModel(INavigationService navigationService,
            ITemplateQuestionRepositoryFactory repositoryFactory, ITemplateQuestionViewModelFactory viewModelFactory, IQuestionTypeRepositoryFactory questionTypeRepositoryFactory)
            : base(navigationService, repositoryFactory, viewModelFactory)
        {
            using (var questionTypeRepository = questionTypeRepositoryFactory.CreateRepository())
            {
                QuestionTypes = questionTypeRepository.Get().ToList();
            }
        }

        private TemplateViewModel _templateViewModel;

        public IEnumerable<QuestionType> QuestionTypes { get; }

        public override void OnNavigationServicePropertyChange(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "CurrentPageKey") return;

            if (NavigationService.CurrentPageKey != Routes.Routes.AddQuestion.Key) return;

            UpdateEntityViewModelFromNavigationParameter();
        }

        protected override void UpdateEntityViewModelFromNavigationParameter()
        {
            var templateViewModel = NavigationService.Parameter as TemplateViewModel;
            if (templateViewModel == null) return;

            _templateViewModel = templateViewModel;

            if (_templateViewModel.SelectedQuestion != null)
            {
                EntityViewModel = _templateViewModel.SelectedQuestion;
            }
            else
            {
                EntityViewModel = ViewModelFactory.CreateViewModel();

                EntityViewModel.Template = _templateViewModel.Entity;
                EntityViewModel.Template_Id = templateViewModel.Id;
            }
        }

        public override void Save()
        {
            //TODO: Validation
            
            _templateViewModel.UpdatedEntity.Questions.Add(EntityViewModel.UpdatedEntity);

            GoBack();
        }

        public override void GoBack()
        {
            base.GoBack(_templateViewModel);
        }
    }
}