using System.Data.Entity;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using System.Data.SqlClient;
using System.Data.Common;
using System.Diagnostics;
using System.Windows;
using System.Data;
using Festispec.Domain.LocalDatabase;

namespace Festispec.Domain.Repository.Factory
{
    public abstract class RepositoryFactoryBase<TRepository, TEntity> : IRepositoryFactory<TRepository, TEntity>
        where TRepository : IRepository<TEntity>
        where TEntity : class
    {
        /// <summary>
        ///     Creates a repository of the given TEntity
        /// </summary>
        /// <returns> A new repository of the given TEntity. </returns>
        public abstract TRepository CreateRepository();

        /// <summary>
        ///     Creates an instance of the DbContext
        /// </summary>
        /// <returns> A new instance of the DbContext. </returns>
        protected DbContext GetDbContext()
        {
            if (CanConnect())
            {
                MessageBox.Show("Verbonden met de database!");
                //database syncen
                return new FestispecContainer();
            }
            else
            {
                MessageBox.Show("Error 1337: Niet verbonden met de database!");
                return null;
            }
        }

        protected bool CanConnect()
        {
            bool canConnectToDatabase = false;

            try
            {
                using (var dbContext = new FestispecContainer())
                {
                    canConnectToDatabase = dbContext.Database.Exists();
                }
            }
            catch
            {
                Debug.WriteLine("Geen verbinding");
            }
            return canConnectToDatabase;
        }
    }

}




