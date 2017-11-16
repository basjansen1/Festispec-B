using System;
using System.Data.Entity;
using System.Linq.Expressions;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository
{
    internal class LoginRepository : RepositoryBase<Employee>, ILoginRepository
    {
        public LoginRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public void tryLogin()
        {
            
        }
    }
}
