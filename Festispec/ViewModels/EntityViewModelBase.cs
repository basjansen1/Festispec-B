using System.Collections;
using System.Reflection;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using Festispec.ViewModels.Interface;
using GalaSoft.MvvmLight;

namespace Festispec.ViewModels
{
    public abstract class EntityViewModelBase<TRepositoryFactory, TRepository, TEntity> : ViewModelBase,
        IEntityViewModel<TEntity>
        where TRepositoryFactory : IRepositoryFactory<TRepository, TEntity>
        where TRepository : IRepository<TEntity>
        where TEntity : class, new()
    {
        protected readonly TRepositoryFactory RepositoryFactory;

        protected EntityViewModelBase(TRepositoryFactory repositoryFactory)
        {
            RepositoryFactory = repositoryFactory;
            OriginalValues = new TEntity();
            Entity = new TEntity();

            MapValuesToOriginal();
        }

        protected EntityViewModelBase(TRepositoryFactory repositoryFactory, TEntity entity)
        {
            RepositoryFactory = repositoryFactory;
            OriginalValues = new TEntity();
            Entity = entity;

            MapValuesToOriginal();
        }

        public TEntity Entity { get; }
        public TEntity OriginalValues { get; set; }

        public abstract bool Save();

        public virtual bool Delete()
        {
            using (var repository = RepositoryFactory.CreateRepository())
            {
                return repository.Delete(Entity) != 0;
            }
        }

        public virtual void MapValues(TEntity from, TEntity to)
        {
            // TODO: Slow. Use manual mapping instead
            // Get all the properties of the entity
            var properties = typeof(TEntity).GetProperties();
            foreach (var property in properties)
            {
                try
                {
                    // Map the properties
                    property.SetValue(to, from.GetType().GetProperty(property.Name)?.GetValue(from, null));
                }
                catch (TargetInvocationException ex)
                {
                    
                }
            }
        }

        public void MapValuesFromOriginal() => MapValues(OriginalValues, Entity);
        public void MapValuesToOriginal() => MapValues(Entity, OriginalValues);
    }
}