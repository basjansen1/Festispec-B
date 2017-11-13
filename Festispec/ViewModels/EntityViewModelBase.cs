using Festispec.ViewModels.Interface;
using Festispec.ViewModels.Template;
using GalaSoft.MvvmLight;

namespace Festispec.ViewModels
{
    public abstract class EntityViewModelBase<TRepositoryFactory, TRepository, TEntity> : ViewModelBase, IEntityViewModel<TEntity>
        where TRepositoryFactory : IRepositoryFactory<TRepository>
        where TRepository : IRepository<TEntity>
        where TEntity : class, new()
    {
        public TEntity Entity { get; }
        protected readonly TRepositoryFactory RepositoryFactory;

        protected EntityViewModelBase(TRepositoryFactory repositoryFactory)
        {
            RepositoryFactory = repositoryFactory;
            Entity = new TEntity();
        }

        protected EntityViewModelBase(TRepositoryFactory repositoryFactory, TEntity entity)
        {
            RepositoryFactory = repositoryFactory;
            Entity = entity;
        }

        public abstract void Save();
        public abstract TEntity Copy();
    }
}