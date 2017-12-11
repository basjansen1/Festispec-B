using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using Festispec.NavigationService;
using Festispec.ViewModels.Factory.Interface;
using GalaSoft.MvvmLight.CommandWpf;

namespace Festispec.ViewModels.Question
{
    public class QuestionAddViewModel :
        AddOrUpdateViewModelBase<IQuestionViewModelFactory, QuestionViewModel, IQuestionRepository, Domain.Question>
    {
        private QuestionViewModel _questionViewModel;

        public QuestionAddViewModel(INavigationService navigationService,
            IRepositoryFactory<IQuestionRepository, Domain.Question> repositoryFactory,
            IQuestionViewModelFactory viewModelFactory, IQuestionTypeRepositoryFactory questionTypeRepositoryFactory) :
            base(navigationService, repositoryFactory, viewModelFactory)
        {
            using (var questionTypeRepository = questionTypeRepositoryFactory.CreateRepository())
            {
                QuestionTypes = questionTypeRepository.Get().ToList();
            }

            EntityViewModel.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(EntityViewModel.QuestionType_Type))
                    RaisePropertyChanged(nameof(MetadataVisibility));
            };

            RegisterCommands();

            LoadQuestions();
        }

        public IEnumerable<QuestionType> QuestionTypes { get; }

        public ObservableCollection<QuestionViewModel> Questions { get; set; } =
            new ObservableCollection<QuestionViewModel>();

        public bool IsNewQuestion => SelectedQuestion == null;

        // Allow metadata only when "tabel" or "reeks"
        public Visibility MetadataVisibility => EntityViewModel.QuestionType_Type == "Tabel"
            ? Visibility.Visible
            : Visibility.Collapsed;

        public QuestionViewModel SelectedQuestion
        {
            get { return _questionViewModel; }
            set
            {
                _questionViewModel = value;

                EntityViewModel.MapValues(_questionViewModel?.Entity ?? new Domain.Question(), EntityViewModel.Entity);

                RaisePropertyChanged(nameof(EntityViewModel));
                RaisePropertyChanged(nameof(IsNewQuestion));
                RaisePropertyChanged(nameof(MetadataVisibility));
                RaisePropertyChanged();
            }
        }

        public ICommand ClearSelectedQuestionCommand { get; set; }
        public ICommand SearchQuestionCommand { get; set; }

        private void RegisterCommands()
        {
            ClearSelectedQuestionCommand =
                new RelayCommand(() => SelectedQuestion = null, () => SelectedQuestion != null);
            SearchQuestionCommand = new RelayCommand(LoadQuestions, () => SelectedQuestion == null);
        }

        private void LoadQuestions()
        {
            using (var questionRepository = RepositoryFactory.CreateRepository())
            {
                var query = questionRepository.Get();

                if (!string.IsNullOrWhiteSpace(EntityViewModel.Name))
                    query = query.Where(question => question.Name.Contains(EntityViewModel.Name));
                if (!string.IsNullOrWhiteSpace(EntityViewModel.Description))
                    query = query.Where(question => question.Description.Contains(EntityViewModel.Description));

                var hasQuestionCollection = NavigationService.Parameter as IHasQuestionCollection;
                if (hasQuestionCollection != null)
                {
                    var ignoreIds = hasQuestionCollection.Questions.Select(model => model.Id);
                    query = query.Where(question => !ignoreIds.Contains(question.Id));
                }

                // Clear questions
                Questions.Clear();
                foreach (var question in query.ToList())
                    Questions.Add(ViewModelFactory.CreateViewModel(question));
            }
        }

        public override void Save()
        {
            var saved = EntityViewModel.Save();

            // Return is save failed
            if (!saved)
                return;

            // Overwrite the original values with the new entity values
            EntityViewModel.MapValuesToOriginal();

            // Add question to parent viewmodel
            var hasQuestionCollection = NavigationService.Parameter as IHasQuestionCollection;
            hasQuestionCollection?.AddQuestion(EntityViewModel);

            GoBack(NavigationService.Parameter);
        }

        public override void Cancel()
        {
            Cancel(NavigationService.Parameter);
        }

        public override void OnNavigationServicePropertyChange(object sender, PropertyChangedEventArgs args)
        {
        }
    }
}