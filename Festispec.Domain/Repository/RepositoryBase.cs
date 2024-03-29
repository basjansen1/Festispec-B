﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Festispec.Domain.Repository.Interface;

namespace Festispec.Domain.Repository
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected readonly DbContext DbContext;

        /// <summary>
        ///     Uses dependency injection to get an instance of the database context.
        /// </summary>
        /// <param name="dbContext"></param>
        protected RepositoryBase(DbContext dbContext)
        {
            DbContext = dbContext;
        }

     

        /// <inheritdoc />
        public void Dispose()
        {
            DbContext?.Dispose();
        }

        /// <summary>
        ///     Returns a new query where the entities returned will not be cached in the
        ///     <see cref="T:System.Data.Entity.DbContext" />.
        /// </summary>
        /// <returns> A new query with NoTracking applied. </returns>
        public virtual IQueryable<TEntity> Get()
        {
            return DbContext.Set<TEntity>().AsNoTracking();
        }

        /// <summary>
        ///     Finds an entity with the given primary key values.
        ///     If an entity with the given primary key values exists in the context, then it is
        ///     returned immediately without making a request to the store.  Otherwise, a request
        ///     is made to the store for an entity with the given primary key values and this entity,
        ///     if found, is attached to the context and returned.  If no entity is found in the
        ///     context or the store, then null is returned.
        /// </summary>
        /// <remarks>
        ///     The ordering of composite key values is as defined in the EDM, which is in turn as defined in
        ///     the designer, by the Code First fluent API, or by the DataMember attribute.
        /// </remarks>
        /// <param name="keyValues"> The values of the primary key for the entity to be found. </param>
        /// <returns> The entity found, or null. </returns>
        /// <exception cref="T:System.InvalidOperationException">
        ///     Thrown if multiple entities exist in the context with the primary
        ///     key values given.
        /// </exception>
        /// <exception cref="T:System.InvalidOperationException">
        ///     Thrown if the type of entity is not part of the data model for
        ///     this context.
        /// </exception>
        /// <exception cref="T:System.InvalidOperationException">
        ///     Thrown if the types of the key values do not match the types of
        ///     the key values for the entity type to be found.
        /// </exception>
        /// <exception cref="T:System.InvalidOperationException">Thrown if the context has been disposed.</exception>
        public virtual TEntity Get(params object[] keyValues)
        {
            return DbContext.Set<TEntity>().Find(keyValues);
        }

        /// <summary>
        ///     Asynchronously finds an entity with the given primary key values.
        ///     If an entity with the given primary key values exists in the context, then it is
        ///     returned immediately without making a request to the store.  Otherwise, a request
        ///     is made to the store for an entity with the given primary key values and this entity,
        ///     if found, is attached to the context and returned.  If no entity is found in the
        ///     context or the store, then null is returned.
        /// </summary>
        /// <remarks>
        ///     The ordering of composite key values is as defined in the EDM, which is in turn as defined in
        ///     the designer, by the Code First fluent API, or by the DataMember attribute.
        ///     Multiple active operations on the same context instance are not supported.  Use 'await' to ensure
        ///     that any asynchronous operations have completed before calling another method on this context.
        /// </remarks>
        /// <param name="keyValues"> The values of the primary key for the entity to be found. </param>
        /// <returns> A task that represents the asynchronous find operation. The task result contains the entity found, or null. </returns>
        public virtual async Task<TEntity> GetAsync(params object[] keyValues)
        {
            return await DbContext.Set<TEntity>().FindAsync(keyValues);
        }

        /// <summary>
        ///     Returns the only element of a sequence that satisfies a specified condition or
        ///     a default value if no such element exists; this method throws an exception if more than one element
        ///     satisfies the condition.
        /// </summary>
        /// <param name="predicate"> A function to test an element for a condition. </param>
        /// <returns>
        ///     The single element of the input sequence that satisfies the condition in
        ///     <paramref name="predicate" />, or <c>default</c> if no such element is found.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="predicate" /> is <c>null</c>.
        /// </exception>
        public virtual TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbContext.Set<TEntity>().SingleOrDefault(predicate);
        }

        /// <summary>
        ///     Asynchronously returns the only element of a sequence that satisfies a specified condition or
        ///     a default value if no such element exists; this method throws an exception if more than one element
        ///     satisfies the condition.
        /// </summary>
        /// <remarks>
        ///     Multiple active operations on the same context instance are not supported.  Use 'await' to ensure
        ///     that any asynchronous operations have completed before calling another method on this context.
        /// </remarks>
        /// <param name="predicate"> A function to test an element for a condition. </param>
        /// <returns>
        ///     A task that represents the asynchronous operation.
        ///     The task result contains the single element of the input sequence that satisfies the condition in
        ///     <paramref name="predicate" />, or <c>default</c> if no such element is found.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="predicate" /> is <c>null</c>.
        /// </exception>
        public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbContext.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }

        /// <summary>
        ///     Returns a list of all the elements of a sequence that satisfies a specified condition.
        /// </summary>
        /// <param name="predicate"> A function to test an element for a condition. </param>
        /// <returns>
        ///     A list of all the elements of the input sequence that satisfies the condition in
        ///     <paramref name="predicate" />.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="predicate" /> is <c>null</c>.
        /// </exception>
        public virtual ICollection<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
        {
            return DbContext.Set<TEntity>().Where(predicate).ToList();
        }

        /// <summary>
        ///     Asynchronously returns a list of all the elements of a sequence that satisfies a specified condition.
        /// </summary>
        /// <remarks>
        ///     Multiple active operations on the same context instance are not supported.  Use 'await' to ensure
        ///     that any asynchronous operations have completed before calling another method on this context.
        /// </remarks>
        /// <param name="predicate"> A function to test an element for a condition. </param>
        /// <returns>
        ///     A task that represents the asynchronous operation.
        ///     The task result contains a list of all the elements of the input sequence that satisfies the condition in
        ///     <paramref name="predicate" />.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="predicate" /> is <c>null</c>.
        /// </exception>
        public virtual async Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbContext.Set<TEntity>().Where(predicate).ToListAsync();
        }

        /// <summary>
        ///     Adds the given entity into the database.
        /// </summary>
        /// <remarks>
        ///     Note that entities that are already in the context in some other state will have their state set
        ///     to Added.  Add is a no-op if the entity is already in the context in the Added state.
        /// </remarks>
        /// <param name="entity"> The entity to add. </param>
        /// <returns> The entity. </returns>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="entity" /> is <c>null</c>.
        /// </exception>
        public virtual TEntity Add(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
            DbContext.SaveChanges();
            return entity;
        }

        /// <summary>
        ///     Asynchronously adds the given entity into the database.
        /// </summary>
        /// <remarks>
        ///     Note that entities that are already in the context in some other state will have their state set
        ///     to Added.  Add is a no-op if the entity is already in the context in the Added state.;
        ///     Multiple active operations on the same context instance are not supported.  Use 'await' to ensure
        ///     that any asynchronous operations have completed before calling another method on this context.
        /// </remarks>
        /// <param name="entity"> The entity to add. </param>
        /// <returns> A task that represents the asynchronous add operation. The task result contains the entity added. </returns>
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        ///     Updates the given entity into the database.
        ///     Note that the entity must exist in the context in some other state before this method
        ///     is called.
        /// </summary>
        /// <param name="updated"> The entity with the updated values. </param>
        /// <param name="keyValues"> The values of the primary key for the entity to be updated. </param>
        /// <returns> The entity updated. </returns>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="updated" /> is <c>null</c>.
        /// </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="keyValues" /> is <c>null</c>.
        /// </exception>
        public virtual TEntity Update(TEntity updated, params object[] keyValues)
        {
            if (updated == null)
                throw new ArgumentNullException(nameof(updated));

            var existing = Get(keyValues);

            if (existing == null)
                return null;

            DbContext.Entry(existing).CurrentValues.SetValues(updated);
            DbContext.SaveChanges();
            return existing;
        }

        /// <summary>
        ///     Asynchronously updates the given entity into the database.
        ///     Note that the entity must exist in the context in some other state before this method
        ///     is called.
        /// </summary>
        /// <remarks>
        ///     Multiple active operations on the same context instance are not supported.  Use 'await' to ensure
        ///     that any asynchronous operations have completed before calling another method on this context.
        /// </remarks>
        /// <param name="updated"> The entity with the updatll
        /// ed values. </param>
        /// <param name="keyValues"> The values of the primary key for the entity to be updated. </param>
        /// <returns> A task that represents the asynchronous add operation. The task result contains the entity updated. </returns>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="updated" /> is <c>null</c>.
        /// </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="keyValues" /> is <c>null</c>.
        /// </exception>
        public virtual async Task<TEntity> UpdateAsync(TEntity updated, params object[] keyValues)
        {
            if (updated == null)
                throw new ArgumentNullException(nameof(updated));

            var existing = await GetAsync(keyValues);

            if (existing == null)
                return null;

            DbContext.Entry(existing).CurrentValues.SetValues(updated);
            await DbContext.SaveChangesAsync();
            return existing;
        }

        public virtual TEntity AddOrUpdate(TEntity entity)
        {
            DbContext.Set<TEntity>().AddOrUpdate(entity);
            DbContext.SaveChanges();
            return entity;
        }

        public virtual async Task<TEntity> AddOrUpdateAsync(TEntity entity)
        {
            DbContext.Set<TEntity>().AddOrUpdate(entity);
            await DbContext.SaveChangesAsync();
            return entity;  
        }

        /// <summary>
        ///     Deletes the given entity from the database.
        ///     Note that the entity must exist in the context in some other state before this method
        ///     is called.
        /// </summary>
        /// <param name="entity"> The entity to remove. </param>
        /// <returns>
        ///     The number of state entries written to the underlying database. This can include
        ///     state entries for entities and/or relationships. Relationship state entries are created for
        ///     many-to-many relationships and relationships where there is no foreign key property
        ///     included in the entity class (often referred to as independent associations).
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="entity" /> is <c>null</c>.
        /// </exception>
        public virtual int Delete(TEntity entity)
        {
            DbContext.Set<TEntity>().Attach(entity);
            DbContext.Set<TEntity>().Remove(entity);
            return DbContext.SaveChanges();
        }

        public virtual int Delete(params object[] keyValues)
        {
            var entity = Get(keyValues);
            DbContext.Set<TEntity>().Remove(entity);
            return DbContext.SaveChanges();
        }

        /// <summary>
        ///     Asynchronously deletes the given entity from the database.
        ///     Note that the entity must exist in the context in some other state before this method
        ///     is called.
        /// </summary>
        /// <remarks>
        ///     Multiple active operations on the same context instance are not supported.  Use 'await' to ensure
        ///     that any asynchronous operations have completed before calling another method on this context.
        /// </remarks>
        /// <param name="entity"> The entity to remove. </param>
        /// <returns>
        ///     A task that represents the asynchronous save operation.
        ///     The task result contains the number of state entries written to the underlying database. This can include
        ///     state entries for entities and/or relationships. Relationship state entries are created for
        ///     many-to-many relationships and relationships where there is no foreign key property
        ///     included in the entity class (often referred to as independent associations).
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="entity" /> is <c>null</c>.
        /// </exception>
        public virtual async Task<int> DeleteAsync(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
            return await DbContext.SaveChangesAsync();
        }

        /// <summary>
        ///     Returns the number of elements in a sequence.
        /// </summary>
        /// <returns>
        ///     The number of elements in the sequence.
        /// </returns>
        public virtual int Count()
        {
            return DbContext.Set<TEntity>().Count();
        }

        /// <summary>
        ///     Asynchronously returns the number of elements in a sequence.
        /// </summary>
        /// <remarks>
        ///     Multiple active operations on the same context instance are not supported.  Use 'await' to ensure
        ///     that any asynchronous operations have completed before calling another method on this context.
        /// </remarks>
        /// <returns>
        ///     A task that represents the asynchronous operation.
        ///     The task result contains the number of elements in the input sequence.
        /// </returns>
        public virtual async Task<int> CountAsync()
        {
            return await DbContext.Set<TEntity>().CountAsync();
        }
    }

    public static class DbContextExtensionMethods
    {
        public static bool IsAttached(this DbContext dbContext, object entity)
        {
            // Get ObjectContext from DbContext
            var objectContext = ((IObjectContextAdapter)dbContext).ObjectContext;

            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            ObjectStateEntry entry;
            if (objectContext.ObjectStateManager.TryGetObjectStateEntry(entity, out entry))
            {
                return (entry.State != EntityState.Detached);
            }
            return false;
        }
    }
}