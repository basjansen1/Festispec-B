using Festispec.Domain.Repository.Interface;
using Festispec.ViewModels.Inspection;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.NavigationService;
using System.ComponentModel;
using System.Windows.Input;
using Festispec.ViewModels.Factory.Interface;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using Festispec.ViewModels.Template;
using System.Windows;

namespace Festispec.ViewModels.Inspection
{
    public class InspectionQuestionnaireViewModel : AddOrUpdateViewModelBase<IInspectionViewModelFactory, InspectionVM, IInspectionRepository, Domain.Inspection>
    {
        public InspectionQuestionnaireViewModel(INavigationService navigationService, IInspectionRepositoryFactory repositoryFactory, IInspectionViewModelFactory viewModelFactory) : 
            base(navigationService, repositoryFactory, viewModelFactory)
        {
            RegisterCommands();
        }
        public ICommand NavigateToQuestionAddCommand { get; set; }
        public ICommand NavigateToQuestionUpdateCommand { get; set; }
        public ICommand QuestionDeleteCommand { get; set; }
        public ICommand TemplateImportCommand { get; set; }

        public TemplateViewModel SelectedTemplate { get; set; }

        public override void OnNavigationServicePropertyChange(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != nameof(NavigationService.CurrentRoute)) return;

            if (NavigationService.CurrentRoute != Routes.Routes.InspectionQuestionnaire) return;

            UpdateEntityViewModelFromNavigationParameter();
        }

        private void RegisterCommands()
        {
            NavigateToQuestionAddCommand = new RelayCommand(() =>
            {
                EntityViewModel.SelectedQuestion = null;
                NavigationService.NavigateTo(Routes.Routes.QuestionAdd, EntityViewModel);
            }, () => EntityViewModel != null);
            QuestionDeleteCommand = new RelayCommand(() =>
            {
                EntityViewModel.SelectedQuestion.IsDeleted = true;
                EntityViewModel = EntityViewModel;
            }, () => EntityViewModel.SelectedQuestion != null && !EntityViewModel.SelectedQuestion.IsDeleted);
            TemplateImportCommand = new RelayCommand(() => {
                var result = MessageBox.Show("Weet je zeker dat je een template in wilt laden? Dit overschrijft de huidige vragenlijst.", "Waarschuwing", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result != MessageBoxResult.Yes) return;

                ImportTemplate(SelectedTemplate);
                }, () => SelectedTemplate != null);
        }

        private void ImportTemplate(TemplateViewModel selectedTemplate)
        {
            throw new NotImplementedException();
        }

        protected override void UpdateEntityViewModelFromNavigationParameter()
        {
            base.UpdateEntityViewModelFromNavigationParameter();

            EntityViewModel.SelectedQuestion = null;
        }

        public override void Save()
        {
            // TODO: Validation

            base.Save();
        }
    }
}
