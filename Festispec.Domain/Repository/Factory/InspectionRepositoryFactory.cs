using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository.Factory
{
    public class InspectionRepositoryFactory : RepositoryFactoryBase<IInspectionRepository, Inspection>, IInspectionRepositoryFactory
    {
        public override IInspectionRepository CreateRepository()
        {
            return new InspectionRepository(GetDbContext());
        }
    }
}