using System.ComponentModel;
using System.Windows.Input;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using Festispec.NavigationService;
using Festispec.ViewModels.Factory.Interface;
using GalaSoft.MvvmLight.CommandWpf;

namespace Festispec.ViewModels.Template
{
    public class TemplateAddOrUpdateViewModel :
        AddOrUpdateViewModelBase<ITemplateViewModelFactory, TemplateViewModel, ITemplateRepository, Domain.Template>
    {
        public TemplateAddOrUpdateViewModel(INavigationService navigationService,
            ITemplateRepositoryFactory repositoryFactory,
            ITemplateViewModelFactory templateViewModelFactory)
            : base(navigationService, repositoryFactory, templateViewModelFactory)
        {
            RegisterCommands();
        }

        public ICommand NavigateToQuestionAddCommand { get; set; }
        public ICommand NavigateToQuestionUpdateCommand { get; set; }
        public ICommand QuestionDeleteCommand { get; set; }

        private void RegisterCommands()
        {
            NavigateToQuestionAddCommand =
                new RelayCommand(
                    () =>
                    {
                        EntityViewModel.SelectedQuestion = null;
                        NavigationService.NavigateTo(Routes.Routes.TemplateQuestionAdd, EntityViewModel);
                    },
                    () => EntityViewModel != null);
            NavigateToQuestionUpdateCommand = new RelayCommand(
                () => NavigationService.NavigateTo(Routes.Routes.TemplateQuestionAddOrUpdate, EntityViewModel),
                () => EntityViewModel.SelectedQuestion != null && !EntityViewModel.SelectedQuestion.IsDeleted);
            QuestionDeleteCommand = new RelayCommand(() =>
            {
                EntityViewModel.SelectedQuestion.IsDeleted = true;
                EntityViewModel = EntityViewModel;
            }, () => EntityViewModel.SelectedQuestion != null && !EntityViewModel.SelectedQuestion.IsDeleted);
        }

        public override void OnNavigationServicePropertyChange(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != nameof(NavigationService.CurrentRoute)) return;

            if (NavigationService.CurrentRoute != Routes.Routes.TemplateAddOrUpdate) return;

            UpdateEntityViewModelFromNavigationParameter();
        }

        protected override void UpdateEntityViewModelFromNavigationParameter()
        {
            base.UpdateEntityViewModelFromNavigationParameter();

            EntityViewModel.SelectedQuestion = null;
        }

        public override void Save()
        {
            // TODO: Validation

            var saved = EntityViewModel.Save();

            if(saved) GoBack(EntityViewModel);
        }
    }
}