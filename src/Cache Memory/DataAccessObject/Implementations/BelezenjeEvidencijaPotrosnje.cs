using Cache_Memory.DataAccessObject.Interfaces;
using Cache_Memory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache_Memory.DataAccessObject.Implementations
{
    public class BelezenjeEvidencijaPotrosnje : IBelezenjeEvidencijaPotrosnje
    {
        public int Count()
        {
            // broj evidencija upisanih u bazi podataka
            int brojEvidencija = 0;

            // formiranje upita
            string upit = "SELECT COUNT(*) FROM EVIDENCIJAPOTROSNJE";

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
                            brojEvidencija = Convert.ToInt32(komanda.ExecuteScalar());
                        }
                    }
                }
            }

            return brojEvidencija;
        }

        public int Delete(EvidencijaPotrosnje entity)
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
            string query = "SELECT *FROM EVIDENCIJAPOTROSNJE WHERE userId = :user_id";

            using (IDbCommand komanda = konekcija.CreateCommand())
            {
                komanda.CommandText = query;

                Utils.ParameterUtil.AddParameter(komanda, "user_id", DbType.Int32);
                komanda.Prepare();
                Utils.ParameterUtil.SetParameterValue(komanda, "user_id", id);

                return komanda.ExecuteScalar() != null;
            }
        }

        public EvidencijaPotrosnje FindById(int id)
        {
            throw new NotImplementedException();
        }

        public int Save(EvidencijaPotrosnje entity)
        {
            throw new NotImplementedException();
        }

        public int SaveAll(IEnumerable<EvidencijaPotrosnje> entities)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<EvidencijaPotrosnje> FindAll()
        {
            // celokupna evidencija potrosnje
            List<EvidencijaPotrosnje> evidencija = new List<EvidencijaPotrosnje>();

            // formiranje upita
            string upit = "SELECT *FROM EVIDENCIJAPOTROSNJE";

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
                            int userId = reader.GetInt32(0);
                            int brojiloId = reader.GetInt32(1);
                            int mesec = reader.GetInt32(2);
                            string grad = reader.GetString(3);
                            double potrosnja = reader.GetDouble(4);

                            // kreiranje objekta od iscitanih podataka
                            EvidencijaPotrosnje evidencijaPotrosnje = new EvidencijaPotrosnje(userId, brojiloId, mesec, grad, potrosnja);

                            // dodavanje iscitane evidencije u listu
                            evidencija.Add(evidencijaPotrosnje);
                        }
                    }
                }
            }

            return evidencija;
        }

        public IEnumerable<EvidencijaPotrosnje> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EvidencijaPotrosnje> FindByMesec(int mesec)
        {
            // celokupna evidencija potrosnje
            List<EvidencijaPotrosnje> evidencija = new List<EvidencijaPotrosnje>();

            // formiranje upita
            string upit = "SELECT *FROM EVIDENCIJAPOTROSNJE WHERE mesec = :mesec";

            using (IDbConnection konekcija = Connection.ConnectionPool.GetConnection())
            {
                konekcija.Open(); // otvaranje konekcije

                using (IDbCommand komanda = konekcija.CreateCommand())
                {
                    komanda.CommandText = upit;

                    // placeholder za mesec podesavamo sa AddParameter
                    Utils.ParameterUtil.AddParameter(komanda, "mesec", DbType.Int32);
                    komanda.Prepare();

                    // podesavamo parametar koji smo dodali
                    Utils.ParameterUtil.SetParameterValue(komanda, "mesec", mesec);

                    using (IDataReader reader = komanda.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // izdvanje podataka iz procitanog reda u tabeli
                            int userId = reader.GetInt32(0);
                            int brojiloId = reader.GetInt32(1);
                            int mesecDb = reader.GetInt32(2);
                            string grad = reader.GetString(3);
                            double potrosnja = reader.GetDouble(4);

                            // kreiranje objekta od iscitanih podataka
                            EvidencijaPotrosnje evidencijaPotrosnje = new EvidencijaPotrosnje(userId, brojiloId, mesec, grad, potrosnja);

                            // dodavanje iscitane evidencije u listu
                            evidencija.Add(evidencijaPotrosnje);
                        }
                    }
                }
            }

            return evidencija;
        }

        public IEnumerable<EvidencijaPotrosnje> FindByUserId(int id)
        {
            // celokupna evidencija potrosnje
            List<EvidencijaPotrosnje> evidencija = new List<EvidencijaPotrosnje>();

            // formiranje upita
            string upit = "SELECT *FROM EVIDENCIJAPOTROSNJE WHERE userId = :user_id";

            using (IDbConnection konekcija = Connection.ConnectionPool.GetConnection())
            {
                konekcija.Open(); // otvaranje konekcije

                using (IDbCommand komanda = konekcija.CreateCommand())
                {
                    komanda.CommandText = upit;

                    // placeholder za userId podesavamo sa AddParameter
                    Utils.ParameterUtil.AddParameter(komanda, "user_id", DbType.Int32);
                    komanda.Prepare();

                    // podesavamo parametar koji smo dodali
                    Utils.ParameterUtil.SetParameterValue(komanda, "user_id", id);

                    using (IDataReader reader = komanda.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // izdvanje podataka iz procitanog reda u tabeli
                            int userId = reader.GetInt32(0);
                            int brojiloId = reader.GetInt32(1);
                            int mesec = reader.GetInt32(2);
                            string grad = reader.GetString(3);
                            double potrosnja = reader.GetDouble(4);

                            // kreiranje objekta od iscitanih podataka
                            EvidencijaPotrosnje evidencijaPotrosnje = new EvidencijaPotrosnje(userId, brojiloId, mesec, grad, potrosnja);

                            // dodavanje iscitane evidencije u listu
                            evidencija.Add(evidencijaPotrosnje);
                        }
                    }
                }
            }

            return evidencija;
        }

        public IEnumerable<EvidencijaPotrosnje> FindByGrad(string grad)
        {
            throw new NotImplementedException();
        }
    }
}
