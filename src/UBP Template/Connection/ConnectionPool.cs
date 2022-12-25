using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;

namespace UBP_Template.Connection
{
    public class ConnectionPool : IDisposable
    {
        private static IDbConnection instance = null;

        public static IDbConnection GetConnection()
        {
            if (instance == null || instance.State == ConnectionState.Closed)
            {
                OracleConnectionStringBuilder ocsb = new OracleConnectionStringBuilder();

                ocsb.DataSource = Connection.ConnectionParams.LOCAL_DATA_SOURCE;
                ocsb.UserID = Connection.ConnectionParams.USER_ID;
                ocsb.Password = Connection.ConnectionParams.PASSWORD;

                // connection pool parametri
                ocsb.Pooling = true;
                ocsb.MinPoolSize = 1;
                ocsb.MaxPoolSize = 10;
                ocsb.IncrPoolSize = 3;
                ocsb.ConnectionLifeTime = 5;
                ocsb.ConnectionTimeout = 30;

                instance = new OracleConnection(ocsb.ConnectionString);
            }
            return instance;
        }

        public void Dispose()
        {
            if (instance != null)
            {
                instance.Close();
                instance.Dispose();
            }
        }
    }
}
