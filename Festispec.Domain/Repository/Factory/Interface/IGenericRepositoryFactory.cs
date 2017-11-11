using System.Data.Entity;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository.Factory.Interface
{
    public interface IGenericRepositoryFactory<TEntity>
        where TEntity : class
    {
        IGenericRepository<TEntity> CreateRepository();
    }
}