using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository.Factory
{
    public class PlanningRepositoryFactory : RepositoryFactoryBase<IPlanningRepository, Planning>,
        IPlanningRepositoryFactory
    {
        public override IPlanningRepository CreateRepository()
        {
            return new PlanningRepository(GetDbContext());
        }
    }
}