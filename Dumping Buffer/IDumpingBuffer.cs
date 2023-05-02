using Common;
using System.ServiceModel;

namespace Dumping_Buffer
{
    [ServiceContract]
    public interface IDumpingBuffer
    {
        [OperationContract]
        bool DodavanjeURedCekanja(Podatak podaci);

        [OperationContract]
        void UklananjeIzRedaCekanja();

        [OperationContract]
        int TrenutnoURedu();

        [OperationContract]
        bool SlanjePodataka();
    }
}
