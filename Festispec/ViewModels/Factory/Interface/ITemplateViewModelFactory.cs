using Festispec.ViewModels.Interface;
using Festispec.ViewModels.Template;

namespace Festispec.ViewModels.Factory.Interface
{
    public interface ITemplateViewModelFactory : IViewModelFactory<TemplateViewModel, Domain.Template>
    {
    }
}