using Database.Servisi;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Data.Common;

namespace Database
{
    public class UserRegisterBrojilo
    {
        private int idGenerator;
        private int rowsAffected;

        public UserRegisterBrojilo()
        {
            // prazan konstruktor
            idGenerator = 0;
            rowsAffected = -2;
        }

        // dodavanje u tabelu brojilo
        public bool DodavanjeUTabeluBrojilo(string nazivModelBrojila)
        {
            // id se automatski generise
            IDbConnection baza = null;
            IDbCommand command = null;
            IDataReader reader = null;

            try
            {
                baza = Konekcija.CreateDatabaseConnection.GetConnection();
                baza.Open();
                command = baza.CreateCommand();

                // upit za broj korisnika u bazi
                command.CommandText = "SELECT COUNT(*) FROM BROJILO";
                reader = command.ExecuteReader(); // izvrsavanje upita

                if (!((OracleDataReader)reader).HasRows) // tabela brojilo je prazna
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
                }
            }
            catch (DbException)
            {
                return false;
            }

            // upis novog korisnika
            string dodavanjeBrojila = "INSERT INTO BROJILO VALUES(" + idGenerator + ", '" + nazivModelBrojila + "')";

            try
            {
                PushData query = new PushData();
                rowsAffected = query.ExecuteNonQuery(dodavanjeBrojila);
            }
            catch (Exception)
            {
                return false;
            }

            if (rowsAffected != -2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // dodavanje u veznu tabelu korisnikbrojilo
        public bool DodavanjeUVeznuTabeluKorisnikBrojilo(int userId)
        {
            if (rowsAffected != -2)
            {
                // dodavanje u veznu tabelu ima smisla samo ako se prethodno
                // u tabelu brojilo dodalo novo brojilo
                string dodavanjeUVeznuTabelu = "INSERT INTO KORISNIKBROJILO VALUES(" + userId + ", " + idGenerator + ")";

                try
                {
                    PushData query = new PushData();
                    rowsAffected = query.ExecuteNonQuery(dodavanjeUVeznuTabelu);

                    return rowsAffected != -2;
                }
                catch (Exception)
                {
                    // rollback promena ako se desila greska u dodavanju u veznu tabelu
                    try
                    {
                        PushData query = new PushData();
                        rowsAffected = query.ExecuteNonQuery("DELETE FROM BROJILO WHERE ID = " + idGenerator);
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
            return false;
        }
    }
}
