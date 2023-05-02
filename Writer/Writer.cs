using Common;
using Dumping_Buffer;
using System.ServiceModel;

namespace Writer
{
    public class Writer : IWriter
    {
        public bool ProsledjivanjePodatkaNaDumpingBuffer(Podatak podatak)
        {
            ChannelFactory<IDumpingBuffer> kanal = new ChannelFactory<IDumpingBuffer>("DumpingBuffer");
            IDumpingBuffer proxy = kanal.CreateChannel();

            return proxy.DodavanjeURedCekanja(podatak);
        }
    }
}
