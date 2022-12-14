using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.Sqlite;

namespace Database.Konekcija
{
    public class CreateConnection
    {
        SqliteConnection baza = null;
        public CreateConnection(string path)
        {
            try
            {
                baza = new SQLiteConnection("Data Source=evidention.db; Version = 3; New = True; Compress = True; ");
                baza.Open();
            }             
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }
            finally
            {

            }
        }
    }
}
