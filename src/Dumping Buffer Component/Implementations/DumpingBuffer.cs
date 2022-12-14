using Common_Class_Library.Implementations;
using DumpingBuffer_Component.Interfaces;
using Historical_Component.Implementations;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Threading;
using System.Threading.Tasks;

namespace DumpingBuffer_Component.Implementations
{
    public class DumpingBuffer : MarshalByRefObject, IDumpingBuffer
    {

        List<ModelData> queue = null;
        bool InitServie = false;

        public DumpingBuffer()
        {
            queue = new List<ModelData>();
            InitServie = true;
        }

        public void AddToQueue(ModelData podaci)
        {
            if (InitServie)
            {
                #pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                PeriodicCheck();
                #pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

                InitServie = false;
            }

            foreach (ModelData data in queue)
            {
                if (data.Equals(podaci)) // prevent double same entry in queue
                {
                    return;
                }
            }

            queue.Add(podaci);
            Console.WriteLine("[Dumping Buffer] Podatak dodat u queue");
        }

        public void RemoveFromQueue()
        {
            queue.RemoveAt(0); // remove first from queue
            Console.WriteLine("[Dumping Buffer] Podatak poslat i uklonjen iz queue");
        }

        public async Task PeriodicCheck()
        {
            CancellationToken ct = new CancellationToken();
            TimeSpan vreme = new TimeSpan(0, 0, 2); // provera na 2 sekunde

            for (; !ct.IsCancellationRequested;)
            {
                await SendToHistorical(vreme, ct);
            }
        }

        public async Task SendToHistorical(TimeSpan interval, CancellationToken cancellationToken)
        {
            Historical HistroicalINode = RemotingServices.Connect(typeof(Historical), "tcp://localhost:8090/Historical") as Historical;

            if (queue.Count >= 7)
            {
                Console.WriteLine("[Dumping Buffer] Slanje podataka ka Historical");
                for (int i = 0; i < 7; i++)
                {
                    HistroicalINode.WriteModelDataToDataBase(queue[i]);
                }

                for (int i = 0; i < 7; i++)
                {
                    RemoveFromQueue(); // remove wrote data
                }
                Console.WriteLine("[Dumping Buffer] Prenos podataka zavrsen");
            }

            // wait for next iteration
            await Task.Delay(interval, cancellationToken);
            Console.WriteLine("[Dumping Buffer] Trenutno u redu cekanja {0}", queue.Count);
        }
    }
}
