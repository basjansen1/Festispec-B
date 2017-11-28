﻿using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using Festispec.ViewModels.Interface;
using Festispec.ViewModels.Template;
using GalaSoft.MvvmLight;

namespace Festispec.ViewModels
{
    public abstract class EntityViewModelBase<TRepositoryFactory, TRepository, TEntity> : ViewModelBase, IEntityViewModel<TEntity>
        where TRepositoryFactory : IRepositoryFactory<TRepository, TEntity>
        where TRepository : IRepository<TEntity>
        where TEntity : class, new()
    {
        public TEntity Entity { get; }
        public TEntity OriginalValues { get; set; }

        protected readonly TRepositoryFactory RepositoryFactory;

        protected EntityViewModelBase(TRepositoryFactory repositoryFactory)
        {
            RepositoryFactory = repositoryFactory;
            Entity = new TEntity();
            OriginalValues = Copy();
        }

        protected EntityViewModelBase(TRepositoryFactory repositoryFactory, TEntity entity)
        {
            RepositoryFactory = repositoryFactory;
            Entity = entity;
            OriginalValues = Copy();
        }

        public abstract bool Save();

        public virtual bool Delete()
        {
            using (var repository = RepositoryFactory.CreateRepository())
            {
                return repository.Delete(Entity) != 0;
            }
        }

        public abstract TEntity Copy();
    }
}