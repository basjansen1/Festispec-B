using System.ComponentModel;
using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.NavigationService;
using Festispec.ViewModels.Template;

namespace Festispec.ViewModels
{
    public class AddQuestionViewModel :
        AddOrUpdateViewModelBase<ITemplateQuestionViewModelFactory, TemplateQuestionViewModel, TemplateQuestion>
    {
        public AddQuestionViewModel(INavigationService navigationService,
            ITemplateQuestionRepositoryFactory RepositoryFactory, ITemplateQuestionViewModelFactory TemplateVMFactory)
            : base(navigationService, RepositoryFactory, TemplateVMFactory)
        {
        }

        private TemplateViewModel _templateViewModel;

        public override void OnNavigationServicePropertyChange(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "CurrentPageKey") return;

            if (NavigationService.CurrentPageKey != Routes.Routes.AddQuestion.Key) return;

            UpdateEntityViewModelFromNavigationParameter();
        }

        protected override void UpdateEntityViewModelFromNavigationParameter()
        {
            var templateViewModel = NavigationService.Parameter as TemplateViewModel;
            // Create copy or new instance of TEntityViewModel
            if (templateViewModel == null) return;

            _templateViewModel = templateViewModel;

            if (_templateViewModel.SelectedQuestion != null)
            {
                EntityViewModel = ViewModelFactory.CreateViewModel(_templateViewModel.SelectedQuestion);
            }
            else
            {
                EntityViewModel = ViewModelFactory.CreateViewModel();

                EntityViewModel.Template = _templateViewModel.Entity;
            }
        }

        public override void Save()
        {
            _templateViewModel.Questions.Add(EntityViewModel.Entity);
            NavigationService.GoBack(_templateViewModel);
        }
    }
}