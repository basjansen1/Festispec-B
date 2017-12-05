using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festispec.Domain.Repository.Factory
{
    public class RegulationRepositoryFactory : RepositoryFactoryBase<IRegulationRepository, Regulation>, IRegulationRepositoryFactory
    {
        public override IRegulationRepository CreateRepository()
        {
            return new RegulationRepository(GetDbContext());
        }
    }
}
