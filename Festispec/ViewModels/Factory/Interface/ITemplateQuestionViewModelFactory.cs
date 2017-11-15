using Festispec.ViewModels.Interface;
using Festispec.ViewModels.Template;

namespace Festispec.ViewModels.Factory.Interface
{
    public interface ITemplateQuestionViewModelFactory : IViewModelFactory<TemplateQuestionViewModel, Domain.TemplateQuestion>
    {
    }
}