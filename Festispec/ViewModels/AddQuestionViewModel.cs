﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.NavigationService;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.Template;

namespace Festispec.ViewModels
{
    public class AddQuestionViewModel :
        AddOrUpdateViewModelBase<ITemplateQuestionViewModelFactory, TemplateQuestionViewModel, TemplateQuestion>
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
            if (args.PropertyName != nameof(NavigationService.CurrentRoute)) return;

            if (NavigationService.CurrentRoute != Routes.Routes.AddQuestion) return;

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
                EntityViewModel = _templateViewModel.SelectedQuestion;
            }
            else
            {
                EntityViewModel = ViewModelFactory.CreateViewModel();

                EntityViewModel.Template = _templateViewModel.Entity;
            }
        }

        public override void Save()
        {
//            EntityViewModel.Template.Questions.Add(EntityViewModel.Entity);
            EntityViewModel.Save();

            NavigationService.GoBack(_templateViewModel);
        }
    }
}