using Common.Implementations;
using Historical.Interfaces;
using System;
using System.Collections.Generic;

namespace Historical.Implementations
{
    public class Historical : IHistorical
    {
        public IEnumerable<ModelData> GetAllDataFromDataBase()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ModelData> GetSelectedDataByCriteria(string criteriaName, string criteria)
        {
            throw new NotImplementedException();
        }

        public bool WriteModelDataToDataBase(ModelData data)
        {
            throw new NotImplementedException();
        }
    }
}
