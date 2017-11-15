using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository.Factory
{
    public class TemplateRepositoryFactory : RepositoryFactoryBase<Template>, ITemplateRepositoryFactory
    {
        public override IRepository<Template> CreateRepository()
        {
            return new TemplateRepository(GetDbContext());
        }
    }
}