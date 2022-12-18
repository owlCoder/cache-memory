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
            throw new NotImplementedException();
        }

        public EvidencijaPotrosnje FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EvidencijaPotrosnje> FindByMesec(int mesec)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EvidencijaPotrosnje> FindByUserId(int id)
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
            throw new NotImplementedException();
        }

        public IEnumerable<EvidencijaPotrosnje> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EvidencijaPotrosnje> FindByGrad(string grad)
        {
            throw new NotImplementedException();
        }
    }
}
