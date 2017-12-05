﻿using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository.Factory
{
    public class RegulationsRepositoryFactory : RepositoryFactoryBase<IRegulationsRepository, Regulation>, IRegulationsRepositoryFactory
    {
        public RegulationsRepositoryFactory(bool isOnline) : base(isOnline)
        {
        }

        public override IRegulationsRepository CreateRepository()
        {
            return new RegulationsRepository(GetDbContext());
        }
    }
}
