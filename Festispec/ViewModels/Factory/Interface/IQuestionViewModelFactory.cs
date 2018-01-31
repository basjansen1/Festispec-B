using Festispec.ViewModels.Question;

namespace Festispec.ViewModels.Factory.Interface
{
    public interface IQuestionViewModelFactory : IViewModelFactory<QuestionViewModel, Domain.Question>
    {
    }
}