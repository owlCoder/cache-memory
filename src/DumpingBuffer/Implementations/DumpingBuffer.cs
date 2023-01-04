using Common.Implementations;
using DumpingBuffer.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DumpingBuffer.Implementations
{
    public class DumpingBuffer : IDumpingBuffer
    {
        public void AddToQueue(ModelData podaci) // dm
        {
            throw new NotImplementedException();  /// Trace.WriteLine(poruka);
        }

        public void RemoveFromQueue() //dj
        {
            throw new NotImplementedException();
        }

        public Task PeriodicCheck(TimeSpan i, CancellationToken c)
        {
            throw new NotImplementedException();
        }

        public Task SendToHistorical(ModelData podaci)
        {
            throw new NotImplementedException();
        }
    }
}
