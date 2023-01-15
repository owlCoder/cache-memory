using Common_Class_Library.Implementations;
using System.Collections.Generic;

namespace Reader_Component.Interfaces
{
    public interface IReader
    {
        List<ModelData> GetPodaciFromHistorical(string criteriaName, string criteria, bool allData = false);
    }
}
