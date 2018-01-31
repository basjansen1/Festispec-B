using System;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.Question;

namespace Festispec.ViewModels.Template
{
    public class
        TemplateViewModel : EntityViewModelBase<ITemplateRepositoryFactory, ITemplateRepository, Domain.Template>,
            IHasQuestionCollection
    {
        private QuestionViewModel _selectedQuestion;

        public TemplateViewModel(ITemplateRepositoryFactory repositoryFactory,
            IQuestionViewModelFactory questionViewModelFactory) : base(repositoryFactory)
        {
            Questions = new ObservableCollection<QuestionViewModel>(
                Entity.TemplateQuestion.Select(question =>
                    questionViewModelFactory.CreateViewModel(question.Question)));
        }

        public TemplateViewModel(ITemplateRepositoryFactory repositoryFactory,
            IQuestionViewModelFactory questionViewModelFactory, Domain.Template entity)
            : base(repositoryFactory, entity)
        {
            Questions = new ObservableCollection<QuestionViewModel>(
                Entity.TemplateQuestion.Select(question =>
                    questionViewModelFactory.CreateViewModel(question.Question)));
        }

        public int Id => Entity.Id;

        public string Name
        {
            get { return Entity.Name; }
            set
            {
                Entity.Name = value;
                RaisePropertyChanged();
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

        public ObservableCollection<QuestionViewModel> Questions { get; }

        public QuestionViewModel SelectedQuestion
        {
            get { return _selectedQuestion; }
            set
            {
                _selectedQuestion = value;
                RaisePropertyChanged();
            }
        }

        public void AddQuestion(QuestionViewModel question)
        {
            Questions.Add(question);
        }

        public override bool Save()
        {
            // TODO: Validation

            try
            {
                Domain.Template updated;
                var questionsToUpdate = Questions;
                using (var templateRepository = RepositoryFactory.CreateRepository())
                {
                    updated = Id == 0
                        ? templateRepository.Add(Entity)
                        : templateRepository.Update(Entity, Id);

                    foreach (var questionViewModel in questionsToUpdate)
                    {
                        // Delete if needed, else try attach
                        if (questionViewModel.IsDeleted)
                            templateRepository.DetachQuestions(updated, questionViewModel.Entity);
                        else
                            templateRepository.TryAttachQuestion(updated, questionViewModel.Entity);
                    }
                }

                // First we map the updated values to the entity
                MapValues(updated, Entity);
                // Then we overwrite the original values with the new entity values
                MapValuesToOriginal();
            }
            catch (DbEntityValidationException ex)
            {
                var errorList = (from eve in ex.EntityValidationErrors
                    from ve in eve.ValidationErrors
                    select ve.PropertyName).ToList();
                var joined = string.Join(", ", errorList.Select(x => x));
                MessageBox.Show("Veld(en) niet (correct) ingevuld: " + joined);
                return false;
            }
            catch (Exception)
            {
                MessageBox.Show("Er is iets fout gegaan. Controleer of alle velden correct zijn ingevuld.");
                return false;
            }

            return true;
        }

        public override void MapValues(Domain.Template @from, Domain.Template to)
        {
            // Map values
            to.Id = from.Id;
            to.Description = from.Description;
            to.Name = from.Name;

            try
            {
                to.TemplateQuestion = from.TemplateQuestion;
            }
            catch (InvalidOperationException)
            {
                //
            }
        }
    }
}