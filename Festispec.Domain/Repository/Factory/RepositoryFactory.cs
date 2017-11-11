using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository.Factory
{
    public abstract class RepositoryFactory<TEntity> : IRepositoryFactory<TEntity>
        where TEntity : class
    {
        protected readonly FestispecContainer DbContext;

        /// <summary>
        ///     Uses dependency injection to get an instance of the database context.
        /// </summary>
        /// <param name="dbContext"></param>
        protected RepositoryFactory(FestispecContainer dbContext)
        {
            DbContext = dbContext;
        }

        /// <summary>
        ///     Creates a repository of the given TEntity
        /// </summary>
        /// <returns> A new repository of the given TEntity. </returns>
        public abstract IGenericRepository<TEntity> CreateRepository();
    }
}