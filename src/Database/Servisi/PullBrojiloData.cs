using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Data.Common;

namespace Database.Servisi
{
    public class PullBrojiloData : IPullData
    {
        public PullBrojiloData()
        {
            Baza = null;
            Command = null;
            Reader = null;
        }
        public bool GetTargetedDataFromDatabase(int userId, string sql = "")
        {
            try
            {
                Baza = Konekcija.CreateDatabaseConnection.GetConnection();
                Baza.Open();
                Command = Baza.CreateCommand();

                // upit da li u bazi postoji korisnik
                Command.CommandText = "SELECT COUNT(*) FROM KORISNIKBROJILO WHERE USERID = " + userId;

                Reader = Command.ExecuteReader(); // izvrsavanje upita

                if (!((OracleDataReader)Reader).HasRows) // korisnik nema nijedno brojilo
                {
                    return false;
                }
                else
                {
                    Reader.Read(); // pozicioniranje readera na prvi red

                    int brojBrojila = Reader.GetInt32(0);

                    // postoji neko brojilo vezano za datog korisnika ili ono i ne postoji
                    return ((brojBrojila == 0) ? false : true);
                }
            }
            catch (DbException)
            {
                // Trace.WriteLine(e.Message);
                return false;
            }
            finally
            {
                // zatvaranje konekcije ka bazi
                if (Command != null)
                {
                    Command.Dispose();
                }

                if (Reader != null)
                {
                    Reader.Close();
                    Reader.Dispose();
                }

                if (Baza != null)
                {
                    Baza.Close();
                    Baza.Dispose();
                }
            }
        }
        public IDbConnection Baza { get => Baza; set => Baza = value; }
        public IDbCommand Command { get => Command; set => Command = value; }
        public IDataReader Reader { get => Reader; set => Reader = value; }
    }
}
