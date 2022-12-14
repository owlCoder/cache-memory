using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;

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
            //this.ShowMessageAsync("Informacija", "Zatvaranje konekcije");

            if (instance != null)
            {
                instance.Close();
                instance.Dispose();
            }

        }
    }
}
