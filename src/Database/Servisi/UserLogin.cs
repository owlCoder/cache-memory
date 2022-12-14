using Database.Modeli;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

namespace Database.Servisi
{
    public class UserLogin : ILogin
    {
        private static Korisnik korisnik = null;
        public bool LogIn(string username, string password)
        {
            // Korisnik se prijavljuje tako sto unosi svoje korisnicko ime i lozinku
            IDbConnection baza = null;
            IDbCommand command = null;
            IDataReader reader = null;

            try
            {
                baza = Konekcija.CreateDatabaseConnection.GetConnection();
                baza.Open();
                command = baza.CreateCommand();

                // upit da li u bazi postoji korisnik
                command.CommandText = "SELECT *FROM KORISNICI WHERE USERNAME ='" + username +
                                      "' AND PASSWORD = '" + password + "'";

                reader = command.ExecuteReader(); // izvrsavanje upita

                if (!((OracleDataReader)reader).HasRows) // korisnik ne postoji
                {
                    return false;
                }
                else
                {
                    // korisnik postoji
                    // podaci iz baze u klasu model
                    reader.Read(); // pozicioniranje na prvi zapis

                    int userId = reader.GetInt32(0);
                    string userName = reader.GetString(1);
                    string userPassword = reader.GetString(2);
                    string userAddress = reader.GetString(3);

                    try
                    {
                        korisnik = new Korisnik(userId, userName, userPassword, userAddress);

                        return true;
                    }
                    catch (Exception e)
                    {
                        Trace.WriteLine(e.Message);
                        return false;
                    }
                }
            }
            catch (DbException e)
            {
                Trace.WriteLine(e.Message);
                return false;
            }
            finally
            {
                // zatvaranje konekcije ka bazi
                if (command != null)
                {
                    command.Dispose();
                }

                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                }

                if (baza != null)
                {
                    baza.Close();
                    baza.Dispose();
                }
            }
        }
        public static Korisnik Korisnik { get => korisnik; set => korisnik = value; }
    }
}
