using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Servisi
{
    public class PushData : IPushData
    {
        public int ExecuteNonQuery(string sql)
        {
            using (IDbConnection connection = Konekcija.CreateDatabaseConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = sql;
                        int rowsAffected = command.ExecuteNonQuery();   // vraća broj uspešno ažuriranih redova u slucaju DML naredbe ILI
                                                                        // -1 u slucaju uspešnog izvršenja DDL naredbe
                        return rowsAffected;
                    }
                }
                catch (DbException)
                {
                    // Trace.WriteLine(ex.Message);
                    return -2;
                }
                finally
                {
                    if (connection != null)
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                }
            }
        }
    }
}
