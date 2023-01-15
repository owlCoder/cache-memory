using DumpingBuffer_Component.Implementations;
using Historical_Component.Implementations;
using Reader_Component.Implementations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Remoting;
using Writer_Component.Implementations;

namespace IPC_Services
{
    [ExcludeFromCodeCoverage]
    public class InteractionNode
    {
        public Historical HistroicalINode { get; set; }
        public Writer WriterINode { get; set; }
        public DumpingBuffer DumpingBufferINode { get; set; }
        public Reader ReaderINode { get; set; }

        public InteractionNode()
        {
            HistroicalINode = RemotingServices.Connect(typeof(Historical), "tcp://localhost:8090/Historical") as Historical;
            WriterINode = RemotingServices.Connect(typeof(Writer), "tcp://localhost:8086/Writer") as Writer;
            DumpingBufferINode = RemotingServices.Connect(typeof(DumpingBuffer), "tcp://localhost:8085/DumpingBuffer") as DumpingBuffer;
            ReaderINode = RemotingServices.Connect(typeof(Reader), "tcp://localhost:8087/Reader") as Reader;
        }
    }
}
