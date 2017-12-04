using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Festispec.Domain.LocalDatabase
{
    public class SyncClasses
    {
        private string ConnectionString;
        public DataSet myDataSet;

        public SyncClasses()
        {
            Connect();
        }

        public void Connect()
        {
            myDataSet = new DataSetLocalDatabase(); //local database

            ConnectionString = "Data Source=(localdb)\\dev;" + "Initial Catalog=Festispec;"; //connectiestring Festispec Database

            FillDatabase();
        }

        public void FillDatabase()
        {
            string[] TableList = { "Address" }; //nog hardcoded, later automatisch opslaan alle tabels van Festispe Database

            foreach (string s in TableList)
            {
                SqlDataAdapter adp = new SqlDataAdapter("select * from " + s + "", ConnectionString); //maakt connectie tussen dataset en database Festispec
                adp.Fill(myDataSet, s); //registreert het aantal rijen dat geüpdate worden of gevuld, maar moet nog daadwerkelijk gevuld worden
            }
        }       
    }
}
