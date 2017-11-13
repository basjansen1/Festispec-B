using System.ComponentModel;
using System.Linq;
using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.NavigationService;

namespace Festispec.ViewModels.Template
{
    public abstract class TemplateAddOrUpdateViewModel :
        AddOrUpdateViewModelBase<ITemplateViewModelFactory, TemplateViewModel, Domain.Template>
    {
        protected TemplateAddOrUpdateViewModel(INavigationService navigationService,
            ITemplateRepositoryFactory repositoryFactory, ITemplateViewModelFactory templateViewModelFactory)
            : base(navigationService, repositoryFactory, templateViewModelFactory)
        {
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

            var existing = EntityViewModel.Questions.SingleOrDefault(templateQuestion => templateQuestion.Id == templateQuestionViewModel.Id);
            if (existing == null) EntityViewModel.Questions.Add(templateQuestionViewModel.Entity);
//            else
//            {
//                var index = EntityViewModel.Questions.IndexOf(existing);
//                EntityViewModel.Questions.RemoveAt(index);
//                EntityViewModel.Questions.Insert(index, templateQuestionViewModel);
//            }
        }
    }
}