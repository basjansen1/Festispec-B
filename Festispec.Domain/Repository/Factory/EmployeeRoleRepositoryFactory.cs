﻿using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository.Factory
{
    public class EmployeeRoleRepositoryFactory : RepositoryFactoryBase<IEmployeeRoleRepository, EmployeeRole>, IEmployeeRoleRepositoryFactory
    {
        public EmployeeRoleRepositoryFactory(bool isOnline) : base(isOnline)
        {
        }

        public override IEmployeeRoleRepository CreateRepository()
        {
            return new EmployeeRoleRepository(GetDbContext());
        }
    }
}