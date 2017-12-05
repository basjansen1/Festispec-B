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
        DataSet myDataSet; //local database

        //local database


        public SyncClasses()
        {

            myDataSet = new DataSetLocalDatabase();

            Connect();

        }

        public void Connect()
        {

            ConnectionString = "Data Source=(localdb)\\dev;" + "Initial Catalog=Festispec;"; //connectiestring Festispec Database

            FillDatabase();
        }

        public void FillDatabase()
        {
            string[] TableList = { "Address" }; //nog hardcoded, later automatisch opslaan alle tabels van Festispe Database


            foreach (string s in TableList)
            {
                SqlDataAdapter adp = new SqlDataAdapter("select * from " + s + "", ConnectionString); //maakt connectie tussen dataset en database Festispec
                SqlCommandBuilder builder = new SqlCommandBuilder(adp);
                adp.Fill(myDataSet, s); //registreert het aantal rijen dat geüpdate worden of gevuld, maar moet nog daadwerkelijk gevuld worden
                adp.FillSchema(myDataSet, SchemaType.Source, s);



            }
            add(myDataSet);

        }  
        public void add(DataSet d)
        {
            DataTable Address;
            Address = d.Tables["Address"];

            foreach (DataRow drCurrent in Address.Rows)
            {
                Console.WriteLine("{0} {1} {2}",
                drCurrent["Id"].ToString(),
                drCurrent["Street"].ToString(),
                drCurrent["City"].ToString());

            }
            Console.ReadLine();
        }
    }     
}

