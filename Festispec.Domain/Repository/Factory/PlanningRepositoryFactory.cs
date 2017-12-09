using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository.Factory
{
    public class PlanningRepositoryFactory : RepositoryFactoryBase<IPlanningRepository, Planning>,
        IPlanningRepositoryFactory
    {
        public PlanningRepositoryFactory(bool isOnline) : base(isOnline)
        {
        }

        public override IPlanningRepository CreateRepository()
        {
            return new PlanningRepository(GetDbContext());
        }
    }
}