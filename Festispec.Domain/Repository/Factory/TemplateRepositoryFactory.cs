using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository.Factory
{
    public class TemplateRepositoryFactory : RepositoryFactoryBase<ITemplateRepository, Template>, ITemplateRepositoryFactory
    {
        public override ITemplateRepository CreateRepository()
        {
            return new TemplateRepository(GetDbContext());
        }
    }
}