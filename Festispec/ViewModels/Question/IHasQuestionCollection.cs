using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Festispec.ViewModels.Question
{
    public interface IHasQuestionCollection
    {
        ObservableCollection<QuestionViewModel> Questions { get; }
        void AddQuestion(QuestionViewModel question);
    }
}