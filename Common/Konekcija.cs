using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace Common
{
    public class Konekcija
    {
        private static IDbConnection instance = null;

        public static IDbConnection GetConnection()
        {
            return CheckInstanceConnection();
        }

        private static OracleConnectionStringBuilder IDbInitConnection()
        {
            OracleConnectionStringBuilder ocsb = new OracleConnectionStringBuilder
            {
                DataSource = Kreditijali.LOCAL_DATA_SOURCE,
                UserID = Kreditijali.USER_ID,
                Password = Kreditijali.PASSWORD,

                // connection pool parametri
                Pooling = true,
                MinPoolSize = 1,
                MaxPoolSize = 10,
                IncrPoolSize = 3,
                ConnectionLifeTime = 5,
                ConnectionTimeout = 30
            };
            return ocsb;
        }

        private static bool CheckInstance()
        {
            if (instance == null)
                return true;

            if (instance.State == ConnectionState.Closed)
                return true;

            return false;
        }

        private static IDbConnection CheckInstanceConnection()
        {
            if (CheckInstance())
            {
                OracleConnectionStringBuilder ocsb = IDbInitConnection();
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
