using System;
using System.Windows;
using Festispec.Domain.Extension;
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
            try
            {
                using (var repository = RepositoryFactory.CreateRepository())
                {
                    return repository.Delete(Entity) != 0;
                }
            }
            catch (Exception exception)
            {
                // TODO: Generic error message instead of exception message: MessageBox.Show("Er is iets fout gegaan");
                MessageBox.Show(exception.Message);
            }

            return false;
        }

        public abstract void MapValues(TEntity from, TEntity to);

        public void MapValuesFromOriginal() => MapValues(OriginalValues, Entity);
        public void MapValuesToOriginal() => MapValues(Entity, OriginalValues);
    }
}