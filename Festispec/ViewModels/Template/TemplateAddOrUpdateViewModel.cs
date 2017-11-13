using System.ComponentModel;
using System.Linq;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.NavigationService;

namespace Festispec.ViewModels.Template
{
    public abstract class TemplateAddOrUpdateViewModel :
        AddOrUpdateViewModelBase<ITemplateViewModelFactory, TemplateViewModel, Domain.Template>
    {
        private readonly ITemplateQuestionRepositoryFactory _templateQuestionRepositoryFactory;

        protected TemplateAddOrUpdateViewModel(INavigationService navigationService,
            ITemplateRepositoryFactory repositoryFactory,
            ITemplateQuestionRepositoryFactory templateQuestionRepositoryFactory,
            ITemplateViewModelFactory templateViewModelFactory)
            : base(navigationService, repositoryFactory, templateViewModelFactory)
        {
            _templateQuestionRepositoryFactory = templateQuestionRepositoryFactory;
        }

        public override void OnNavigationServicePropertyChange(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "CurrentPageKey") return;

            if (NavigationService.CurrentPageKey != Routes.Routes.TemplateUpdate.Key &&
                NavigationService.CurrentPageKey != Routes.Routes.TemplateAdd.Key) return;

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
//            else
//            {
//                var index = EntityViewModel.Questions.IndexOf(existing);
//                EntityViewModel.Questions.RemoveAt(index);
//                EntityViewModel.Questions.Insert(index, templateQuestionViewModel);
//            }
        }

        public override void Save()
        {
            // TODO: Validation
            EntityViewModel.Save();

            using (var templateQuestionRepository = _templateQuestionRepositoryFactory.CreateRepository())
            {
                foreach (var templateQuestion in EntityViewModel.Questions)
                    if (templateQuestion.Id == 0)
                        templateQuestionRepository.Add(templateQuestion);
                    else
                        templateQuestionRepository.Update(templateQuestion);
            }

            NavigationService.GoBack(EntityViewModel);
        }
    }
}