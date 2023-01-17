using Common_Class_Library.Implementations;
using DumpingBuffer_Component.Implementations;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Remoting;
using Writer_Component.Interfaces;

namespace Writer_Component.Implementations
{
    public class Writer : MarshalByRefObject, IWriter
    {

        // Ne moze biti testirano - Security Sockets Polisa OS Windows
        [ExcludeFromCodeCoverage]
        public void DataPassThrough(ModelData data)
        {
            
            // Log Message
            Console.WriteLine("[REQUEST] SAVE DATA TO BUFFER");

            DumpingBuffer DumpingBufferINode = RemotingServices.Connect(typeof(DumpingBuffer), "tcp://localhost:8085/DumpingBuffer") as DumpingBuffer;
            DumpingBufferINode.AddToQueue(data);

            // Log Message
            Console.WriteLine("[REQUEST] SAVE DATA TO BUFFER SUCCESS\n");
        }

        public void DataPassThrough(DumpingBuffer db, ModelData data)
        {
            // Log Message
            Console.WriteLine("[REQUEST] SAVE DATA TO BUFFER");

            if (db != null)
                db.AddToQueue(data);

            // Log Message
            Console.WriteLine("[REQUEST] SAVE DATA TO BUFFER SUCCESS\n");
        }
    }
}
