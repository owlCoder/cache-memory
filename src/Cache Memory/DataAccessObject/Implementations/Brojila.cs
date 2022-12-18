using Cache_Memory.DataAccessObject.Interfaces;
using Cache_Memory.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Cache_Memory.DataAccessObject.Implementations
{
    public class Brojila : IBrojila
    {
        public int Count()
        {
            int brojBrojila = 0;

            // formiranje upita
            string upit = "SELECT COUNT(*) FROM BROJILO";

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
                            brojBrojila = Convert.ToInt32(komanda.ExecuteScalar());
                        }
                    }
                }
            }

            return brojBrojila;
        }

        public int Delete(Brojilo entity)
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
            string query = "SELECT *FROM BROJILO WHERE brojiloId = :brojilo_id";

            using (IDbCommand komanda = konekcija.CreateCommand())
            {
                komanda.CommandText = query;

                Utils.ParameterUtil.AddParameter(komanda, "brojilo_id", DbType.Int32);
                komanda.Prepare();
                Utils.ParameterUtil.SetParameterValue(komanda, "brojilo_id", id);

                return komanda.ExecuteScalar() != null;
            }
        }

        public IEnumerable<Brojilo> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Brojilo> FindAllById(IEnumerable<int> ids)
        {
            // lista brojila
            List<Brojilo> listaBrojila = new List<Brojilo>();

            // formiranje upita
            string upit = "SELECT *FROM BROJILO";

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
                            string naziv = reader.GetString(1);

                            // kreiranje objekta od iscitanih podataka
                            Brojilo brojilo = new Brojilo(id, naziv);

                            // dodavanje iscitanog brojila u listu
                            listaBrojila.Add(brojilo);
                        }
                    }
                }
            }

            return listaBrojila;
        }

        public Brojilo FindById(int id)
        {
            throw new NotImplementedException();
        }

        public int Save(Brojilo entity)
        {
            throw new NotImplementedException();
        }

        public int SaveAll(IEnumerable<Brojilo> entities)
        {
            throw new NotImplementedException();
        }
    }
}
