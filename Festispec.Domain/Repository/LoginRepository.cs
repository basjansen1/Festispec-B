using System.Data.Entity;
using System.Linq;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository
{
    public class LoginRepository : RepositoryBase<Employee>, ILoginRepository
    {
        public LoginRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public bool TryLogin(string username, string password)
        {
            return Get().Any(employee => employee.Username == username && employee.Password == password);
        }
    }
}