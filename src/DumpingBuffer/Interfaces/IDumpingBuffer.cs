using Common.Implementations;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DumpingBuffer.Interfaces
{
    public interface IDumpingBuffer
    {
        void AddToQueue(ModelData podaci); //dm

        void RemoveFromQueue(int userID); //dm

        Task SendToHistorical(ModelData podaci); //dj

        Task PeriodicCheck(TimeSpan i, CancellationToken c); //dj
    }
}
