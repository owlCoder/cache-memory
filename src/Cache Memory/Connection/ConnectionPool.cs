using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Cache_Memory.Connection
{
    public class ConnectionPool : IDisposable
    {
        private static IDbConnection instance = null;

        public static IDbConnection GetConnection()
        {
            if(instance == null || instance.State == ConnectionState.Closed)
            {
                OracleConnectionStringBuilder ocsb = new OracleConnectionStringBuilder();

                // dinamicko podesavanje data parametara
                ocsb.DataSource = ConnectionParameters.DATA_SOURCE;
                ocsb.UserID = ConnectionParameters.USER_ID;
                ocsb.Password = ConnectionParameters.PASSWORD;

                // podesavanje connection pool parametara
                ocsb.Pooling = true;            // omoguciti connection pool
                ocsb.MinPoolSize = 1;           // minimalni broj konekcija u pool-u
                ocsb.MaxPoolSize = 10;          // maksimalni broj konekcija u pool-u
                ocsb.IncrPoolSize = 3;          // koliko konekcija se moze uzeti ako "zafali"
                ocsb.ConnectionLifeTime = 5;    // zivotni vek konekcije
                ocsb.ConnectionTimeout = 30;    // vreme isteka konekcije ako se ne koristi

                // kreiranje nove konekcije prema bazi podataka
                instance = new OracleConnection(ocsb.ConnectionString);
            }

            return instance;
        }
        public void Dispose()
        {
            if(instance != null)
            {
                instance.Close();
                instance.Dispose();
            }    
        }
    }
}
