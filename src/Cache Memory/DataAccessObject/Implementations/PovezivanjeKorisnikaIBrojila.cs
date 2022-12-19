using Cache_Memory.DataAccessObject.Interfaces;
using Cache_Memory.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Cache_Memory.DataAccessObject.Implementations
{
    public class PovezivanjeKorisnikaIBrojila : IPovezivanjeKorisnikaIBrojila
    {
        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Delete(KorisnikBrojilo entity)
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
            throw new NotImplementedException();
        }

        public IEnumerable<KorisnikBrojilo> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KorisnikBrojilo> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KorisnikBrojilo> FindAllBrojilaPerUser(int userId)
        {
            // lista brojila
            List<KorisnikBrojilo> lista = new List<KorisnikBrojilo>();

            // formiranje upita
            string upit = "SELECT *FROM KORISNIKBROJILO WHERE userId = :user_id";

            using (IDbConnection konekcija = Connection.ConnectionPool.GetConnection())
            {
                konekcija.Open(); // otvaranje konekcije

                using (IDbCommand komanda = konekcija.CreateCommand())
                {
                    komanda.CommandText = upit;

                    Utils.ParameterUtil.AddParameter(komanda, "user_id", DbType.Int32);
                    komanda.Prepare();
                    Utils.ParameterUtil.SetParameterValue(komanda, "user_id", userId);

                    using (IDataReader reader = komanda.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // izdvanje podataka iz procitanog reda u tabeli
                            int user_id = reader.GetInt32(0);
                            int brojilo_id = reader.GetInt32(1);

                            // kreiranje objekta od iscitanih podataka
                            KorisnikBrojilo kb = new KorisnikBrojilo(user_id, brojilo_id);

                            // dodavanje iscitanog korisnik-brojila u listu
                            lista.Add(kb);
                        }
                    }
                }
            }

            return lista;
        }

        public KorisnikBrojilo FindById(int id)
        {
            throw new NotImplementedException();
        }

        public int Save(KorisnikBrojilo entity)
        {
            // formiranje upita
            string upit = "INSERT INTO KORISNIKBROJILO VALUES (:user_id, :brojilo_id)";

            using (IDbConnection konekcija = Connection.ConnectionPool.GetConnection())
            {
                konekcija.Open(); // otvaranje konekcije

                using (IDbCommand komanda = konekcija.CreateCommand())
                {
                    komanda.CommandText = upit;

                    // dodavanje parametera i tipova
                    Utils.ParameterUtil.AddParameter(komanda, "user_id", DbType.Int32);
                    Utils.ParameterUtil.AddParameter(komanda, "brojilo_id", DbType.Int32);

                    komanda.Prepare();

                    // postavljanje vrednosti
                    Utils.ParameterUtil.SetParameterValue(komanda, "brojilo_id", entity.UserId);
                    Utils.ParameterUtil.SetParameterValue(komanda, "naziv", entity.BrojiloId);

                    komanda.Prepare();

                    // upis brojila u bazu podataka
                    int rowsAffected = komanda.ExecuteNonQuery();

                    return rowsAffected;
                }
            }
        }

        public int SaveAll(IEnumerable<KorisnikBrojilo> entities)
        {
            using (IDbConnection konekcija = Connection.ConnectionPool.GetConnection())
            {
                konekcija.Open();
                IDbTransaction transakcija = konekcija.BeginTransaction(); // pocetak transakcije

                int brojSacuvanihRedova = 0;

                // cuvamo red po red
                foreach (KorisnikBrojilo tmp in entities)
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
