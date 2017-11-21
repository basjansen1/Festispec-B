using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository.Factory
{
    public class CustomerRepositoryFactory : RepositoryFactoryBase<Inspection>, IInspectionRepositoryFactory
    {
        public override IRepository<Inspection> CreateRepository()
        {
            return new InspectionRepository(GetDbContext());
        }
    }
}