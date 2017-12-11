using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository.Factory
{
    public class TemplateRepositoryFactory : RepositoryFactoryBase<ITemplateRepository, Template>, ITemplateRepositoryFactory
    {
        public TemplateRepositoryFactory(bool isOnline) : base(isOnline)
        {
        }

        public override ITemplateRepository CreateRepository()
        {
            return new TemplateRepository(GetDbContext());
        }
    }
}