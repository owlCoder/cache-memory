using Common_Class_Library.Implementations;
using System.Collections.Generic;

namespace Historical_Component.Interfaces
{
    public interface IHistorical
    {
        int WriteModelDataToDataBase(ModelData data);

        IEnumerable<ModelData> GetAllDataFromDataBase();

        IEnumerable<ModelData> GetSelectedDataByCriteria(string value, string criteria);
    }
}
