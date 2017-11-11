namespace Festispec.ViewModels.Template
{
    public abstract class AddOrUpdateTemplateViewModel :
        AddOrUpdateViewModel<ITemplateRepository, TemplateViewModel, Template>
    {
        protected AddOrUpdateTemplateViewModel(IRepositoryFactory<ITemplateRepository> repositoryFactory)
            : base(repositoryFactory)
        {
        }
    }
}