using Common_Class_Library.Implementations;
using DumpingBuffer_Component.Implementations;
using System;
using System.Runtime.Remoting;
using Writer_Component.Interfaces;

namespace Writer_Component.Implementations
{
    public class Writer : MarshalByRefObject, IWriter
    {
        public void DataPassThrough(ModelData data)
        {
            DumpingBuffer DumpingBufferINode = RemotingServices.Connect(typeof(DumpingBuffer), "tcp://localhost:8085/DumpingBuffer") as DumpingBuffer;
            DumpingBufferINode.AddToQueue(data);
        }
    }
}
