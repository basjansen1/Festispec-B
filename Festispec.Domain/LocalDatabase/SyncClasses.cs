using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festispec.Domain.LocalDatabase
{
    public class SyncClasses
    {
        private SqlConnection objConn;
        public DataSet myDataSet;

        public SyncClasses()
        {
            Connect();
        }

        public void Connect()
        {
            myDataSet = new DataSetLocalDatabase();

            string sConnectionString;
            sConnectionString = "Initial Catalog=Festispec;" + "Data Source=(localdb)\\dev";
            objConn = new SqlConnection(sConnectionString);
            objConn.Open();
        }

        public SqlDataAdapter GetAdapter(string TableName)
        {
            return new SqlDataAdapter("Select * From " + TableName + "", objConn);
        }
    }
}
