using Common;
using System.Collections.Generic;
using System.ServiceModel;

namespace Reader
{
    [ServiceContract]
    public interface IReader
    {
        [OperationContract]
        List<Podatak> ProcitajPodatkeIzHistorical(string criteriaName, string criteria, bool allData = false);
    }
}
