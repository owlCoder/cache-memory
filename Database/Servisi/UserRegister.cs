using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

namespace Database.Servisi
{
    public class UserRegister : IRegister
    {
        public bool Register(string username, string password, string adresa)
        {
            // Korisnik se registruje tako sto unosi svoje korisnicko ime i lozinku i adresu
            // id se automatski generise
            IDbConnection baza = null;
            IDbCommand command = null;
            IDataReader reader = null;

            try
            {
                baza = Konekcija.CreateDatabaseConnection.GetConnection();
                baza.Open();
                command = baza.CreateCommand();
                int idGenerator = 0;

                // upit za broj korisnika u bazi
                command.CommandText = "SELECT COUNT(*) FROM KORISNICI";
                reader = command.ExecuteReader(); // izvrsavanje upita

                if (!((OracleDataReader)reader).HasRows) // tabela korisnici je prazna
                {
                    idGenerator = 1;
                }
                else
                {
                    reader.Read(); // pozicioniranje na prvi zapis

                    idGenerator = reader.GetInt32(0);
                    idGenerator += 1;


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

                    try
                    {
                        // upis novog korisnika
                        string dodavanjeKorisnika = "INSERT INTO KORISNICI VALUES(" + idGenerator +
                                                    ", '" + username + "', '" + password +
                                                    "', '" + adresa + "')";

                        int rowsAffected = -2;
                        try
                        {
                            PushData query = new PushData();
                            rowsAffected = query.ExecuteNonQuery(dodavanjeKorisnika);
                        }
                        catch(Exception)
                        {
                            return false;
                        }

                        if (rowsAffected != -2)
                        {
                            // prijava korisnika nakon registracije
                            UserLogin prijava = new UserLogin();
                            bool prijavaUspesna = prijava.LogIn(username, password);

                            if(prijavaUspesna)
                            {
                                return true;
                            }

                            return false;
                        }

                        return false;
                    }
                    catch (Exception)
                    {
                        // Trace.WriteLine(e.Message);
                        return false;
                    }
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
            return false;
        }
    }
}
