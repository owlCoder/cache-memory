using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Database.Konekcija
{
    public class CreateDatabaseConnection : IDisposable
    {
        private static IDbConnection instance = null;

        public static IDbConnection GetConnection()
        {
            if (instance == null || instance.State == ConnectionState.Closed)
            {
                OracleConnectionStringBuilder ocsb = new OracleConnectionStringBuilder();

                ocsb.DataSource = DatabaseConnectionParams.LOCAL_DATA_SOURCE;
                ocsb.UserID = DatabaseConnectionParams.USER_ID;
                ocsb.Password = DatabaseConnectionParams.PASSWORD;

                instance = new OracleConnection(ocsb.ConnectionString);
            }

            return instance;
        }

        public void Dispose()
        {
            // Console.WriteLine("Zatvaranje konekcije");
            if (instance != null)
            {
                instance.Close();
                instance.Dispose();
            }

        }
    }
}
