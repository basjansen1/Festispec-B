using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository.Factory
{
    public class RegulationRepositoryFactory : RepositoryFactoryBase<IRegulationRepository, Regulation>, IRegulationRepositoryFactory
    {
        public RegulationRepositoryFactory(bool isOnline) : base(isOnline)
        {
        }

        public override IRegulationRepository CreateRepository()
        {
            return new RegulationRepository(GetDbContext());
        }
    }
}
