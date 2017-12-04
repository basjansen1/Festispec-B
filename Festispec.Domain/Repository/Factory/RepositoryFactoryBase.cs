using System.Data.Entity;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using System.Data.SqlClient;
using System.Data.Common;
using System.Diagnostics;
using System.Net;

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
            try
            {
                return new FestispecContainer();
            }
            catch
            {
                Debug.WriteLine("Geen verbinding");
                return null;
            }           
        }

        //protected bool IsConnected()
        //{
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

        /// <summary>
        /// Checks if there is an active internet connection
        /// </summary>
        /// <returns>true or false</returns>
        public bool HasInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead("http://www.google.nl"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}