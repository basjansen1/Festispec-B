using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
        TemplateViewModel : EntityViewModelBase<ITemplateRepositoryFactory, ITemplateRepository, Domain.Template>
    {
        private QuestionViewModel _selectedQuestion;

        public TemplateViewModel(ITemplateRepositoryFactory repositoryFactory,
            IQuestionViewModelFactory questionViewModelFactory) : base(repositoryFactory)
        {
            Questions = new ObservableCollection<QuestionViewModel>(
                Entity.TemplateQuestion.Select(question => questionViewModelFactory.CreateViewModel(question.Question));
            Questions.CollectionChanged += QuestionsOnCollectionChanged;
        }

        public TemplateViewModel(ITemplateRepositoryFactory repositoryFactory,
            IQuestionViewModelFactory questionViewModelFactory, Domain.Template entity)
            : base(repositoryFactory, entity)
        {
            Questions = new ObservableCollection<QuestionViewModel>(
                Entity.TemplateQuestion.Select(question => questionViewModelFactory.CreateViewModel(question.Question));
            Questions.CollectionChanged += QuestionsOnCollectionChanged;
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

        private void QuestionsOnCollectionChanged(object sender,
            NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            switch (notifyCollectionChangedEventArgs.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Entity.Questions.Add(((TemplateQuestionViewModel) notifyCollectionChangedEventArgs.NewItems[0])
                        .Entity);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Entity.Questions.Remove(((TemplateQuestionViewModel) notifyCollectionChangedEventArgs.OldItems[0])
                        .Entity);
                    break;
            }
        }

        public override bool Save()
        {
            try
            {
                Domain.Template updated;
                var questionsToUpdate = Questions;
                using (var templateRepository = RepositoryFactory.CreateRepository())
                {
                    updated = Id == 0
                        ? templateRepository.Add(Entity)
                        : templateRepository.Update(Entity, Id);
                }

                // First we map the updated values to the entity
                MapValues(updated, Entity);
                // Then we overwrite the original values with the new entity values
                MapValuesToOriginal();

                foreach (var templateQuestionViewModel in questionsToUpdate)
                {
                    // Manually attach the template by id
                    templateQuestionViewModel.Template_Id = Entity.Id;
                    templateQuestionViewModel.Save();
                }
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

            return true;
        }
    }
}