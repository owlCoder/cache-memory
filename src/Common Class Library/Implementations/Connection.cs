using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace Common_Class_Library.Implementations
{
    public class Connection : IDisposable
    {
        private static IDbConnection instance = null;

        public static IDbConnection GetConnection()
        {
            if (instance == null || instance.State == ConnectionState.Closed)
            {
                OracleConnectionStringBuilder ocsb = new OracleConnectionStringBuilder();

                ocsb.DataSource = ConnectionParams.LOCAL_DATA_SOURCE;
                ocsb.UserID = ConnectionParams.USER_ID;
                ocsb.Password = ConnectionParams.PASSWORD;

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

        [ExcludeFromCodeCoverage]
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
