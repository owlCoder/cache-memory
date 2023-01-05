﻿using Common.Implementations;
using DumpingBuffer.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DumpingBuffer.Implementations
{
    public class DumpingBuffer : IDumpingBuffer
    {
        /// Trace.WriteLine(poruka);

        List<ModelData> queue = new List<ModelData>();

        public void AddToQueue(ModelData podaci) // dm
        {
            foreach(ModelData data in queue)
            {
                if(data.userID == podaci.userID)
                {
                    return;
                }
            }

            queue.Add(podaci);
        }

        public void RemoveFromQueue(string userID) //dm
        {
            for (int i = 0; i < queue.Count; i++)
            {
                if (queue[i].userID == userID)
                {
                    queue.RemoveAt(i);
                }
            }
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
