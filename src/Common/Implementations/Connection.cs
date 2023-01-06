using Common.Interfaces;
using System;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Implementations
{
    public class Connection
    {
        private static IDbConnection instance = null;

        [Obsolete]
        public static IDbConnection GetConnection()
        {
            if (instance == null || instance.State == System.Data.ConnectionState.Closed)
            {
                OracleConnectionStringBuilder ocsb = new OracleConnectionStringBuilder();

                ocsb.UserID = "ers_db";
                ocsb.Password = "ers";
                ocsb.DataSource = "//localhost:1521/xe";
                ocsb.Pooling = true;
                ocsb.MinPoolSize = 1;
                ocsb.MaxPoolSize = 10;             

                instance = new OracleConnection(ocsb.ConnectionString);                
            }          
           
            return instance;
        }

        public void Dispose()
        {
            Console.WriteLine("Closing connection...");
            if (instance != null)
            {
                instance.Close();
                instance.Dispose();
            }

        }

    }
}
