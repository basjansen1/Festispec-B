using Festispec.Domain.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festispec.Domain.Repository.Factory.Interface
{
    public interface IRegulationRepositoryFactory : IRepositoryFactory<IRegulationRepository, Regulation>
    {
    }
}
