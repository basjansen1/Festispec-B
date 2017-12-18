namespace Festispec.Domain.Repository.Interface
{
    public interface ILoginRepository : IRepository<Employee>
    {
        bool TryLogin(string username, string password);
    }
}