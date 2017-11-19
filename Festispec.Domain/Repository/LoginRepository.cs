using System;
using System.Data.Entity;
using System.Linq.Expressions;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository
{
    public class LoginRepository : RepositoryBase<Employee>, ILoginRepository
    {
        public LoginRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public void TryLogin(Expression<Func<Employee, bool>> employee)
        {
            Find(employee);
        }
    }
}
