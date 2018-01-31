using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festispec.OfflineSync
{
    public class OfflineSync
    {

        public string ConnectionStringSource;
        public string ConnectionStringDestination;

        public OfflineSync()
        {
            // TODO: Get these connection strings from App.config
            ConnectionStringSource = "Data Source=(localdb)\\dev;" + "Initial Catalog=Festispec;"; //connectiestring Festispec Database
            ConnectionStringDestination = "Data Source=(localdb)\\dev;" + "Initial Catalog=Festispec.Local;"; //connectiestring naar lokaledb
        }

        public void Sync()
        {
            string[] TableList = { "Address", "Address_Contact","EmployeeRole", "Address_Employee", "Address_Inspector",
                "Address_Customer", "Note", "InspectionStatus", "Address_Inspection", "Planning",
                "QuestionType", "Question", "InspectionQuestion", "InspectionQuestionAnswer", "Regulation", "Template", "TemplateQuestion", "Schedule"}; 

            using (SqlConnection sourceConnection =
                   new SqlConnection(ConnectionStringSource))
            {
                sourceConnection.Open();
                using (SqlConnection destinationConnection =
                       new SqlConnection(ConnectionStringDestination))
                {
                    destinationConnection.Open();

                    foreach (string s in TableList.Reverse()) {
                        // Delete data from local database
                        SqlCommand deleteLocalDataSqlCommand = new SqlCommand(
                            "DELETE " +
                            "FROM " + s, destinationConnection);
                        deleteLocalDataSqlCommand.ExecuteNonQuery();
                    }

                    // Perform an initial count on the destination table.
                    foreach (string s in TableList)
                    {
                        // Get data from the source table as a SqlDataReader.
                        SqlCommand commandSourceData = new SqlCommand(
                            "SELECT * " +
                            "FROM " + s, sourceConnection);

                        using(var reader = commandSourceData.ExecuteReader()) {
                            // Set up the bulk copy object. 
                            // Note that the column positions in the source
                            // data reader match the column positions in 
                            // the destination table so there is no need to
                            // map columns.
                            using (SqlBulkCopy bulkCopy =
                                       new SqlBulkCopy(destinationConnection, SqlBulkCopyOptions.KeepIdentity, null))
                            {
                                bulkCopy.DestinationTableName = s;

                                try
                                {
                                    // Write from the source to the destination.
                                    bulkCopy.WriteToServer(reader);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
