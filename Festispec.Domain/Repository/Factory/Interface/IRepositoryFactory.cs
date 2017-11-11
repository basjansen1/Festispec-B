using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository.Factory.Interface
{
    public interface IRepositoryFactory<TEntity>
        where TEntity : class
    {
        IGenericRepository<TEntity> CreateRepository();
    }
}