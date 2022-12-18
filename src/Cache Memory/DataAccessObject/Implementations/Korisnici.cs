using Cache_Memory.DataAccessObject.Interfaces;
using Cache_Memory.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Cache_Memory.DataAccessObject.Implementations
{
    public class Korisnici : IKorisnici
    {
        public int Count()
        {
            // broj korisnika u bazi podataka
            int brojKorisnika = 0;

            // formiranje upita
            string upit = "SELECT COUNT(*) FROM KORISNIK";

            using (IDbConnection konekcija = Connection.ConnectionPool.GetConnection())
            {
                konekcija.Open(); // otvaranje konekcije

                using (IDbCommand komanda = konekcija.CreateCommand())
                {
                    komanda.CommandText = upit;
                    komanda.Prepare();

                    using (IDataReader reader = komanda.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            brojKorisnika = Convert.ToInt32(komanda.ExecuteScalar());
                        }
                    }
                }
            }

            return brojKorisnika;
        }

        public int Delete(Korisnik entity)
        {
            throw new NotImplementedException();
        }

        public int DeleteAll()
        {
            throw new NotImplementedException();
        }

        public int DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public bool ExistById(int id)
        {
            using (IDbConnection konekcija = Connection.ConnectionPool.GetConnection())
            {
                konekcija.Open(); // otvaranje konekcije

                return ExistsById(id, konekcija);
            }
        }

        private bool ExistsById(int id, IDbConnection konekcija)
        {
            string query = "SELECT *FROM KORISNIK WHERE userId = :user_id";

            using (IDbCommand komanda = konekcija.CreateCommand())
            {
                komanda.CommandText = query;

                Utils.ParameterUtil.AddParameter(komanda, "user_id", DbType.Int32);
                komanda.Prepare();
                Utils.ParameterUtil.SetParameterValue(komanda, "user_id", id);

                return komanda.ExecuteScalar() != null;
            }
        }

        private bool ExistsByAttributeString(string attribute, string attributeValue, IDbConnection konekcija)
        {
            string query = "SELECT *FROM KORISNIK WHERE '" + attribute + "' = :attribute_value";

            using (IDbCommand komanda = konekcija.CreateCommand())
            {
                komanda.CommandText = query;

                Utils.ParameterUtil.AddParameter(komanda, "attribute_value", DbType.String, 32);
                komanda.Prepare();
                Utils.ParameterUtil.SetParameterValue(komanda, "attribute_value", attributeValue);

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

        public IEnumerable<Korisnik> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
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

        private int FindMaxId()
        {
            int maxId = 0;

            // formiranje upita
            string upit = "SELECT MAX(userId) FROM KORISNIK";

            using (IDbConnection konekcija = Connection.ConnectionPool.GetConnection())
            {
                konekcija.Open(); // otvaranje konekcije

                using (IDbCommand komanda = konekcija.CreateCommand())
                {
                    komanda.CommandText = upit;
                    komanda.Prepare();

                    using (IDataReader reader = komanda.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            maxId = Convert.ToInt32(komanda.ExecuteScalar());
                        }
                    }
                }
            }

            return maxId + 1;
        }

        public int Save(Korisnik entity)
        {
            // formiranje upita
            string upit = "INSERT INTO KORISNIK VALUES (:user_id, :username, :password, :adresa)";

            using (IDbConnection konekcija = Connection.ConnectionPool.GetConnection())
            {
                konekcija.Open(); // otvaranje konekcije

                using (IDbCommand komanda = konekcija.CreateCommand())
                {
                    komanda.CommandText = upit;

                    // dodavanje parametera i tipova
                    Utils.ParameterUtil.AddParameter(komanda, "user_id", DbType.Int32);
                    Utils.ParameterUtil.AddParameter(komanda, "username", DbType.String, 32);
                    Utils.ParameterUtil.AddParameter(komanda, "password", DbType.String, 32);
                    Utils.ParameterUtil.AddParameter(komanda, "adresa", DbType.String, 32);

                    komanda.Prepare();
                    
                    // postavljanje vrednosti
                    Utils.ParameterUtil.SetParameterValue(komanda, "user_id", entity.UserId);
                    Utils.ParameterUtil.SetParameterValue(komanda, "username", entity.Username);
                    Utils.ParameterUtil.SetParameterValue(komanda, "password", entity.Password);
                    Utils.ParameterUtil.SetParameterValue(komanda, "adresa", entity.Adresa);

                    komanda.Prepare();
                    // upis korisnika u bazu podataka

                    int rowsAffected = komanda.ExecuteNonQuery();

                    return rowsAffected;
                }
            }
        }

        public int SaveAll(IEnumerable<Korisnik> entities)
        {
            using (IDbConnection konekcija = Connection.ConnectionPool.GetConnection())
            {
                konekcija.Open();
                IDbTransaction transakcija = konekcija.BeginTransaction(); // pocetak transakcije

                int brojSacuvanihRedova = 0;

                // cuvamo red po red
                foreach (Korisnik tmp in entities)
                {
                    brojSacuvanihRedova += Save(tmp);
                }

                // transakcija je prosla okej, promene primenjujemo na bazu podataka
                transakcija.Commit();

                return brojSacuvanihRedova;
            }
        }
    }
}
