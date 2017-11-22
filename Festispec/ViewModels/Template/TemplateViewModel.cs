using System;
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

        public override void Save()
        {
            try
            {
                Domain.Template updated;
                using (var templateRepository = RepositoryFactory.CreateRepository())
                {
                    updated = UpdatedEntity.Id == 0
                        ? templateRepository.Add(UpdatedEntity)
                        : templateRepository.Update(UpdatedEntity, UpdatedEntity.Id);
                }

                // Map updated values
                Entity.Id = updated.Id;
                Entity.Name = updated.Name;
                Entity.Description = updated.Description;

                foreach (var templateQuestionViewModel in QuestionsWithDeleted)
                {
                    // Manually attach the template by id
                    templateQuestionViewModel.UpdatedEntity.Template_Id = Entity.Id;
                    templateQuestionViewModel.Save();
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show("Er is iets foutgegaan.");
            }
        }

        public override void Delete()
        {
            using (var templateRepository = RepositoryFactory.CreateRepository())
            {
                templateRepository.Delete(Entity);
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