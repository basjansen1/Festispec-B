﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using Festispec.ViewModels.Factory.Interface;

namespace Festispec.ViewModels.Template
{
    public class
        TemplateViewModel : EntityViewModelBase<ITemplateRepositoryFactory, ITemplateRepository, Domain.Template>
    {
        private readonly ITemplateQuestionViewModelFactory _templateQuestionViewModelFactory;

        private TemplateQuestionViewModel _selectedQuestion;

        public TemplateViewModel(ITemplateRepositoryFactory repositoryFactory,
            ITemplateQuestionViewModelFactory templateQuestionViewModelFactory) : base(repositoryFactory)
        {
            _templateQuestionViewModelFactory = templateQuestionViewModelFactory;
        }

        public TemplateViewModel(ITemplateRepositoryFactory repositoryFactory,
            ITemplateQuestionViewModelFactory templateQuestionViewModelFactory, Domain.Template entity)
            : base(repositoryFactory, entity)
        {
            _templateQuestionViewModelFactory = templateQuestionViewModelFactory;
        }

        public int Id => Entity.Id;


        public string Name
        {
            get { return Entity.Name; }
            set
            {
                Entity.Name = value;
                RaisePropertyChanged();
                // TODO: Figure out which one works...
                //RaisePropertyChanged();
                //RaisePropertyChanged(null);
                //RaisePropertyChanged("");
                //RaisePropertyChanged(string.Empty);
            }
        }


        public string Description
        {
            get { return Entity.Description; }
            set
            {
                Entity.Description = value;
                RaisePropertyChanged();
            }
        }

        public ICollection<TemplateQuestionViewModel> Questions
        {
            get { return QuestionsWithDeleted.Where(model => !model.IsDeleted).ToList(); }
            set
            {
                Entity.Questions = value.Select(templateQuestionViewModel => templateQuestionViewModel.Entity).ToList();
                RaisePropertyChanged();
            }
        }

        private IEnumerable<TemplateQuestionViewModel> QuestionsWithDeleted => Entity.Questions
            .Select(
                templateQuestion => _templateQuestionViewModelFactory?.CreateViewModel(templateQuestion))
            .ToList();

        public TemplateQuestionViewModel SelectedQuestion
        {
            get { return _selectedQuestion; }
            set
            {
                _selectedQuestion = value;
                RaisePropertyChanged();
            }
        }

        public override bool Save()
        {
            try
            {
                Domain.Template updated;
                using (var templateRepository = RepositoryFactory.CreateRepository())
                {
                    updated = Id == 0
                        ? templateRepository.Add(Entity)
                        : templateRepository.Update(Entity, Id);
                }

                // Map updated values
                // TODO: MapToOriginalValues
                Entity.Id = updated.Id;
                Entity.Name = updated.Name;
                Entity.Description = updated.Description;

                foreach (var templateQuestionViewModel in QuestionsWithDeleted)
                {
                    // Manually attach the template by id
                    templateQuestionViewModel.Template_Id = Entity.Id;
                    templateQuestionViewModel.Save();
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                var ErrorList = (from eve in ex.EntityValidationErrors from ve in eve.ValidationErrors select ve.PropertyName).ToList();
                string joined = string.Join(",", ErrorList.Select(x => x));
                MessageBox.Show("Veld(en) niet (correct) ingevuld: " + joined);
                return false;
            }

            return true;
        }

        public override bool Delete()
        {
            using (var templateRepository = RepositoryFactory.CreateRepository())
            {
                return templateRepository.Delete(Entity) != 0;
            }
        }

        public override Domain.Template Copy()
        {
            return new Domain.Template
            {
                Id = Id,
                Name = Name,
                Description = Description,
                Questions = Entity.Questions
            };
        }
    }
}