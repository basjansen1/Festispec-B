﻿using Festispec.Domain.Repository.Interface;
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

        public IQueryable<Regulation> GetByMunicipality(string municipality)
        {
            return base.Get().Where(r => r.Municipality == municipality);
        }

        public override Regulation Add(Regulation entity)
        {
            entity = CleanRelations(entity);

            return base.Add(entity);
        }

        public override Regulation Update(Regulation updated, params object[] keyValues)
        {
            updated = CleanRelations(updated);

            return base.Update(updated, keyValues);
        }

        private Regulation CleanRelations(Regulation entity)
        {

            return entity;
        }
    }
}
