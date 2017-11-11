namespace Festispec.ViewModels.Template
{
    public class AddTemplateViewModel : AddOrUpdateTemplateViewModel
    {
        public AddTemplateViewModel(IRepositoryFactory<ITemplateRepository> repositoryFactory)
            : base(repositoryFactory)
        {
        }
    }
}