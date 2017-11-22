﻿using System.ComponentModel;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.NavigationService;

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
            if (args.PropertyName != "CurrentPageKey") return;

            if (NavigationService.CurrentPageKey != Routes.Routes.TemplateQuestionAdd.Key) return;

            UpdateEntityViewModelFromNavigationParameter();
        }

        public override void Save()
        {
            //TODO: Validation

            TemplateViewModel.UpdatedEntity.Questions.Add(EntityViewModel.UpdatedEntity);

            GoBack();
        }
    }
}