namespace Festispec.ViewModels.Template
{
    public class UpdateTemplateViewModel : AddOrUpdateTemplateViewModel
    {
        public UpdateTemplateViewModel(IRepositoryFactory<ITemplateRepository> repositoryFactory)
            : base(repositoryFactory)
        {
        }
    }
}