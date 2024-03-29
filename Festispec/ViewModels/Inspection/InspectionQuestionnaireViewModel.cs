﻿using Festispec.Domain.Repository.Interface;
using Festispec.ViewModels.Inspection;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.NavigationService;
using System.ComponentModel;
using System.Windows.Input;
using Festispec.ViewModels.Factory.Interface;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Festispec.ViewModels.Template;
using System.Windows;

namespace Festispec.ViewModels.Inspection
{
    public class InspectionQuestionnaireViewModel : AddOrUpdateViewModelBase<IInspectionViewModelFactory, InspectionVM, IInspectionRepository, Domain.Inspection>
    {
        public InspectionQuestionnaireViewModel(INavigationService navigationService, IInspectionRepositoryFactory repositoryFactory, IInspectionViewModelFactory viewModelFactory, ITemplateRepositoryFactory templateRepositoryFactory, IQuestionViewModelFactory questionViewModelFactory) : 
            base(navigationService, repositoryFactory, viewModelFactory)
        {
            _questionViewModelFactory = questionViewModelFactory;
            using (var templateRepository = templateRepositoryFactory.CreateRepository())
            {
                Templates = new ObservableCollection<Domain.Template>(templateRepository.Get().ToList());;
            }

            RegisterCommands();
        }
        public ICommand NavigateToQuestionAddCommand { get; set; }
        public ICommand NavigateToQuestionUpdateCommand { get; set; }
        public ICommand QuestionDeleteCommand { get; set; }
        public ICommand TemplateImportCommand { get; set; }

        public Domain.Template SelectedTemplate { get; set; }
        public ObservableCollection<Domain.Template> Templates { get; set; }

        private readonly IQuestionViewModelFactory _questionViewModelFactory;

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
            }, () => EntityViewModel != null && NavigationService.CanAndHasAccess(Routes.Routes.QuestionAdd));

            QuestionDeleteCommand = new RelayCommand(() =>
            {
                EntityViewModel.SelectedQuestion.IsDeleted = true;
                EntityViewModel = EntityViewModel;
                EntityViewModel.DeleteQuestion(EntityViewModel.SelectedQuestion); //
            }, () => EntityViewModel.SelectedQuestion != null && !EntityViewModel.SelectedQuestion.IsDeleted);

            TemplateImportCommand = new RelayCommand(() => {
                var result = MessageBox.Show("Weet je zeker dat je een template in wilt laden? Dit voegt een vragenlijst aan de huidige vragen toe.", "Waarschuwing", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result != MessageBoxResult.Yes) return;

                ImportTemplate(SelectedTemplate);
                }, () => SelectedTemplate != null);
        }

        private void ImportTemplate(Domain.Template selectedTemplate)
        {
            foreach (var question in selectedTemplate.TemplateQuestion)
            {
                EntityViewModel.AddQuestion(_questionViewModelFactory.CreateViewModel(question.Question));
            }
                
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
