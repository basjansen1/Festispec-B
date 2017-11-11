using System.Data.Entity;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository.Factory
{
    public abstract class RepositoryFactory<TEntity> : IRepositoryFactory<TEntity>
        where TEntity : class
    {
        /// <summary>
        ///     Creates a repository of the given TEntity
        /// </summary>
        /// <returns> A new repository of the given TEntity. </returns>
        public abstract IGenericRepository<TEntity> CreateRepository();

        /// <summary>
        ///     Creates an instance of the DbContext
        /// </summary>
        /// <returns> A new instance of the DbContext. </returns>
        protected DbContext GetDbContext()
        {
            return new FestispecContainer();
        }
    }
}