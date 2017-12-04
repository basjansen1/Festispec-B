using Festispec.Domain.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festispec.Domain.Repository
{
    class RegulationRepository : RepositoryBase<Regulation>, IRegulationRepository
    {
        public RegulationRepository(DbContext dbContext) : base(dbContext)
        {
        }

      //  public override IQueryable<Regulation> Get()
        //{
          //  return base.Get().Include(regulation => regulation.Name);
        //}
    }
}
