using Cache_Memory.DataAccessObject.Interfaces;
using Cache_Memory.Models;
using System;
using System.Collections.Generic;

namespace Cache_Memory.DataAccessObject.Implementations
{
    public class Brojila : IBrojila
    {
        public int Count()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public IEnumerable<Brojilo> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Brojilo> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
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
