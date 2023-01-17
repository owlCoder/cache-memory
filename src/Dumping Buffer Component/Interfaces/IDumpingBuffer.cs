using Common_Class_Library.Implementations;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DumpingBuffer_Component.Interfaces
{
    public interface IDumpingBuffer
    {
        void AddToQueue(ModelData podaci);

        void RemoveFromQueue();

        Task SendToHistorical(TimeSpan i, CancellationToken c);

        Task PeriodicCheck();
    }
}
