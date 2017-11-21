using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository.Factory.Interface
{
    public interface IRepositoryFactory<out TRepository, TEntity>
        where TRepository : IRepository<TEntity>
        where TEntity : class
    {
        TRepository CreateRepository();
    }
}