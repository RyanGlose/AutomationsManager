using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationsManager.Core.Processes
{
    public static class SQLHelper
    {
        public static void BackupDatabase(string databaseName)
        {
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost\\SQLSERVER2016";
            builder.InitialCatalog = databaseName;
            builder.UserID = "admin";
            builder.Password = "admin";

            using (var connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();

                string commandString = "BACKUP DATABASE " + databaseName + " TO DISK = 'D:\\SQL\\backup.bak' " +
                                 "WITH COPY_ONLY, COMPRESSION";

                using (var command = new SqlCommand(commandString, connection))
                {
                    //var result = command.ExecuteNonQuery();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = reader.GetString(0);
                        }
                    }
                }
            }
        }
    }
}
