using Cache_Memory.DataAccessObject.Interfaces;
using Cache_Memory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public KorisnikBrojilo FindById(int id)
        {
            throw new NotImplementedException();
        }

        public int Save(KorisnikBrojilo entity)
        {
            throw new NotImplementedException();
        }

        public int SaveAll(IEnumerable<KorisnikBrojilo> entities)
        {
            throw new NotImplementedException();
        }
    }
}
