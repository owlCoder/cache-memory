using Common.Interfaces;
using System;
using System.Data;
<<<<<<< HEAD
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
=======
>>>>>>> 4568c90602755a426eb670d1ced8d7f7034bc7c9

namespace Common.Implementations
{
    public class Connection : IConnection
    {
        private static IDbConnection instance = null;

        [Obsolete]
        public IDbConnection GetConnection()
        {
            if (instance == null || instance.State == System.Data.ConnectionState.Closed)
            {
                OracleConnectionStringBuilder ocsb = new OracleConnectionStringBuilder();

                ocsb.UserID = ConnectionParams.USER_ID;
                ocsb.Password = ConnectionParams.PASSWORD;
                ocsb.DataSource = ConnectionParams.LOCAL_DATA_SOURCE;
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
