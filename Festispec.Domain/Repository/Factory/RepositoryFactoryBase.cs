using System.Data.Entity;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using System.Data.SqlClient;
using System.Data.Common;
using System.Diagnostics;
using System.Windows;

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
                return new FestispecContainer();
            }
            else
            {
                Debug.WriteLine("Geen verbinding");
                return null;
            }           
        }

        protected bool CanConnect()
        {
            //    string connection = "(localDB)\\dev";

            //    try
            //    {
            //        using (var connection = new SqlConnection())
            //        {
            //            connection.Open();
            //            return true;
            //        }
            //    }
            //    catch
            //    {
            //        return false;
            //    }
            //}

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