using System.Data.Entity;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using System.Data.SqlClient;
using System.Data.Common;
using System.Diagnostics;
using System.Data;

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
            if (isConnected())
            {
                return new FestispecContainer();
            }
            else
            {
                Debug.WriteLine("Geen verbinding");
                return null;
            }
        }
        protected bool isConnected()
        {
           // string connectionString = "metadata = res://*/Festispec.csdl|res://*/Festispec.ssdl|res://*/Festispec.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=(localdb)\\dev;initial catalog=Festispec;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;";

            using(SqlConnection connection = new SqlConnection("Data Source='(localdb)\\dev';Initial Catalog='Festispec';"))
            {
                try
                {
                    connection.Open();
                    Debug.WriteLine("You have been successfully connected to the database!");
                        return true;
                }
                catch (SqlException)
                {
                Debug.WriteLine("Connection failed.");
                return false;
                }
            }
            
        }
    }

}




