using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using UBP_Template.DAO.Interfaces;
using UBP_Template.Models;

namespace UBP_Template.DAO.Implementations
{
    public class Korisnici : IKorisnici
    {
        public int Count()
        {
            int brojKorisnika = 0;
            string upit = "SELECT COUNT(*) FROM KORISNIK";

            using(IDbConnection konekcija = Connection.ConnectionPool.GetConnection())
            {
                konekcija.Open();

                using(IDbCommand komanda = konekcija.CreateCommand())
                {
                    komanda.CommandText = upit;
                    komanda.Prepare();

                    using(IDataReader reader = komanda.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            brojKorisnika = Convert.ToInt32(komanda.ExecuteScalar());
                            //Trace.WriteLine("kori: " + brojKorisnika);
                        }
                    }
                }
            }

            return brojKorisnika;
        }

        public int Delete(Korisnik entity)
        {
            return DeleteById(entity.UserId);
        }

        public int DeleteAll()
        {
            int rowsAffected = -2;
            string upit = "DELETE FROM KORISNIK";

            using(IDbConnection konekcija = Connection.ConnectionPool.GetConnection())
            {
                konekcija.Open();

                using(IDbCommand komanda = konekcija.CreateCommand())
                {
                    komanda.CommandText = upit;
                    komanda.Prepare();

                    rowsAffected = komanda.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }

        public int DeleteAllUsernameStarts(string username)
        {
            int rowsAffected = -2;
            string upit = "SELECT *FROM KORISNIK WHERE username LIKE :username";

            using(IDbConnection konekcija = Connection.ConnectionPool.GetConnection())
            {
                konekcija.Open();

                using(IDbCommand komanda = konekcija.CreateCommand())
                {
                    komanda.CommandText = upit;

                    Utils.ParameterUtil.AddParameter(komanda, "username", DbType.String, 32);
                    komanda.Prepare();

                    // sa tacno tim korisnicim imenom
                    // Utils.ParameterUtil.SetParameterValue(komanda, "username", username);

                    // sa korisnikom cije kor. ime pocinje sa ....
                    Utils.ParameterUtil.SetParameterValue(komanda, "username", (username + "%"));

                    rowsAffected = komanda.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }

        public int DeleteById(int id)
        {
            int rowsAffected = -2;
            string upit = "DELETE FROM KORISNIK WHERE userId = :user_id";

            using (IDbConnection konekcija = Connection.ConnectionPool.GetConnection())
            {
                konekcija.Open();

                using(IDbCommand komanda = konekcija.CreateCommand())
                {
                    komanda.CommandText = upit;
                    Utils.ParameterUtil.AddParameter(komanda, "user_id", DbType.Int32);
                    // Utils.ParameterUtil.AddParameter(komanda, "username", DbType.String, 32);
                    komanda.Prepare();
                    Utils.ParameterUtil.SetParameterValue(komanda, "user_id", id);
                    // Utils.ParameterUtil.SetParameterValue(komanda, "username", usernameKorisnik);

                    rowsAffected = komanda.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }

        public bool ExistById(int id)
        {
            using(IDbConnection konekcija = Connection.ConnectionPool.GetConnection())
            {
                konekcija.Open();

                return ExistsById(id, konekcija);
            }
        }

        private bool ExistsById(int id, IDbConnection konekcija)
        {
            string upit = "SELECT userId FROM KORISNIK WHERE userId = :user_id";

            using(IDbCommand komanda = konekcija.CreateCommand())
            {
                komanda.CommandText = upit;

                Utils.ParameterUtil.AddParameter(komanda, "user_id", DbType.Int32);
                komanda.Prepare();
                Utils.ParameterUtil.SetParameterValue(komanda, "user_id", id);

                return komanda.ExecuteScalar() != null;
            }
        }

        public IEnumerable<Korisnik> FindAll()
        {
            // lista korisnika
            List<Korisnik> listaKorisnika = new List<Korisnik>();

            // formiranje upita
            string upit = "SELECT *FROM KORISNIK";

            using (IDbConnection konekcija = Connection.ConnectionPool.GetConnection())
            {
                konekcija.Open(); // otvaranje konekcije

                using (IDbCommand komanda = konekcija.CreateCommand())
                {
                    komanda.CommandText = upit;
                    komanda.Prepare();

                    using (IDataReader reader = komanda.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // izdvanje podataka iz procitanog reda u tabeli
                            int id = reader.GetInt32(0);
                            string korisnickoIme = reader.GetString(1);
                            string sifra = reader.GetString(2);
                            string adresa = reader.GetString(3);

                            // kreiranje objekta od iscitanih podataka
                            Korisnik korisnik = new Korisnik(id, korisnickoIme, sifra, adresa);

                            // dodavanje iscitanog korisnika u listu korisnika
                            listaKorisnika.Add(korisnik);
                        }
                    }
                }
            }

            return listaKorisnika;
        }

        public Korisnik FindById(int id)
        {
            // pretpostavka: trazeni korisnik ne postoji
            Korisnik trazeniKorisnik = null;

            // upit za pretragu korisnika
            string upit = "SELECT username, password, adresa FROM KORISNIK WHERE userId = :id_unos";

            using (IDbConnection konekcija = Connection.ConnectionPool.GetConnection())
            {
                konekcija.Open();

                using (IDbCommand komanda = konekcija.CreateCommand())
                {
                    komanda.CommandText = upit;

                    // placeholder za id podesavamo sa AddParameter
                    Utils.ParameterUtil.AddParameter(komanda, "id_unos", DbType.Int32);

                    komanda.Prepare();

                    // podesavamo parametar koji smo dodali
                    Utils.ParameterUtil.SetParameterValue(komanda, "id_unos", id);

                    using (IDataReader reader = komanda.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // izdvanje podataka iz procitanog reda u tabeli
                            string korisnickoIme = reader.GetString(0);
                            string sifra = reader.GetString(1);
                            string adresa = reader.GetString(2);

                            // kreiranje objekta od iscitanih podataka
                            Korisnik korisnik = new Korisnik(id, korisnickoIme, sifra, adresa);

                            trazeniKorisnik = korisnik;
                        }
                    }
                }
            }

            return trazeniKorisnik;
        }

        public int Save(Korisnik entity)
        {
            // INSERT INTO KORISNIK VALUES(1, 'ana10',  'ps1', 'Ugrinovacka 12, Leta');
            string insert_upit = "INSERT INTO KORISNIK (username, password, adresa, userId) " +
                                 "VALUES(:username, :password, :adresa, :user_id)";
            // UPDATE KORISNIK SET username = 'rddsaad', password = '111', adresa = '/' WHERE userId = 12;
            string update_upit = "UPDATE KORISNIK SET username = :username, password = :password, adresa = :adresa " +
                                 "WHERE userId = :user_id";
            string upit = "";

            if(ExistById(entity.UserId) == true)
            {
                upit = update_upit;
            }
            else
            {
                upit = insert_upit;
            }

            using(IDbConnection konekcija = Connection.ConnectionPool.GetConnection())
            {
                konekcija.Open();

                using (IDbCommand komanda = konekcija.CreateCommand())
                {
                    komanda.CommandText = upit;

                    // :username, :password, :adresa, :user_id
                    Utils.ParameterUtil.AddParameter(komanda, "username", DbType.String, 32);
                    Utils.ParameterUtil.AddParameter(komanda, "password", DbType.String, 32);
                    Utils.ParameterUtil.AddParameter(komanda, "adresa", DbType.String, 32);
                    Utils.ParameterUtil.AddParameter(komanda, "user_id", DbType.Int32);

                    komanda.Prepare();

                    Utils.ParameterUtil.SetParameterValue(komanda, "username", entity.Username);
                    Utils.ParameterUtil.SetParameterValue(komanda, "password", entity.Password);
                    Utils.ParameterUtil.SetParameterValue(komanda, "adresa", entity.Adresa);
                    Utils.ParameterUtil.SetParameterValue(komanda, "user_id", entity.UserId);

                    return komanda.ExecuteNonQuery();
                }
            }
        }

        public int SaveAll(IEnumerable<Korisnik> entities)
        {
            using(IDbConnection konekcija = Connection.ConnectionPool.GetConnection())
            {
                konekcija.Open();
                IDbTransaction transaction = konekcija.BeginTransaction();

                int rowsAffected = 0;

                foreach(Korisnik trenutni in entities)
                {
                    rowsAffected += Save(trenutni);
                }

                transaction.Commit();

                return rowsAffected;
            }
        }
    }
}
