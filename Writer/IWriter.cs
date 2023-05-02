using Common;
using System.ServiceModel;

namespace Writer
{
    [ServiceContract]
    public interface IWriter
    {
        [OperationContract]
        bool ProsledjivanjePodatkaNaDumpingBuffer(Podatak podatak);
    }
}
