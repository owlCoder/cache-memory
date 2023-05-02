using Common;
using System.Collections.Generic;
using System.ServiceModel;

namespace Historical
{
    [ServiceContract]
    public interface IHistorical
    {
        [OperationContract]
        int UpisPodatkaUBazuPodataka(Podatak data);

        [OperationContract]
        IEnumerable<Podatak> SviPodaciIzBazePodataka();

        [OperationContract]
        IEnumerable<Podatak> OdredjeniPodaciIzBazePodataka(string criteria, string value);
    }
}
