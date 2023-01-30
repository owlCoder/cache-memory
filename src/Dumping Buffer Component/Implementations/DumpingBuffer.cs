using Common_Class_Library.Implementations;
using DumpingBuffer_Component.Interfaces;
using Historical_Component.Implementations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.Remoting;
using System.Threading;
using System.Threading.Tasks;

namespace DumpingBuffer_Component.Implementations
{
    public class DumpingBuffer : MarshalByRefObject, IDumpingBuffer
    {
        List<ModelData> queue = null;
        bool InitService = false;

        public DumpingBuffer()
        {
            queue = new List<ModelData>();
            InitService = true;
        }

        public void AddToQueue(ModelData podaci)
        {
            if (InitService)
            {
                #pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                PeriodicCheck();
                #pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

                InitService = false;
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
            SnapshotJsonDataTemp();
        }

        public void RemoveFromQueue()
        {
            queue.RemoveAt(0); // remove first from queue
            Console.WriteLine("[Dumping Buffer] Podatak poslat i uklonjen iz queue");
        }

        public int QueueSize()
        {
            // calculate how much queue has
            return queue.Count;
        }

        [ExcludeFromCodeCoverage]
        public async Task PeriodicCheck()
        {
            CancellationToken ct = new CancellationToken();
            TimeSpan vreme = new TimeSpan(0, 0, 2); // provera na 2 sekunde

            for (; !ct.IsCancellationRequested;)
            {
                await SendToHistorical(vreme, ct);
            }
        }

        public async Task SendToHistorical(TimeSpan i, CancellationToken c)
        {
            Historical HistroicalINode = RemotingServices.Connect(typeof(Historical), "tcp://localhost:8090/Historical") as Historical;

            // provera da li treba slati podatke ka bazi podataka
            SendDataToDatabase(HistroicalINode);

            Console.WriteLine("[Dumping Buffer] Trenutno u redu cekanja {0}", queue.Count);

            // wait for next iteration
            await Task.Delay(i, c);
        }

        public bool SendDataToDatabase(Historical HistroicalINode)
        {
            if (queue.Count >= 7)
            {
                Console.WriteLine("[Dumping Buffer] Slanje podataka ka Historical");
                for (int i = 0; i < 7; i++)
                {
                    HistroicalINode.WriteModelDataToDataBase(queue[0]);
                    RemoveFromQueue(); // remove wrote data
                }

                Console.WriteLine("[Dumping Buffer] Prenos podataka zavrsen");

                SaveDataToJson();

                return true;
            }

            return false;
        }

        [ExcludeFromCodeCoverage]
        public void LoadDataToQueue()
        {
            if (File.Exists("buffer.json"))
            {
                Console.WriteLine("[LOAD] READING DATA FROM FILE");
                string jsonFromFile = File.ReadAllText("buffer.json");

                queue = JsonConvert.DeserializeObject<List<ModelData>>(jsonFromFile);
                Console.WriteLine("[LOAD] DATA LOADED SUCCESSFULY");
                Console.WriteLine("[Dumping Buffer] Trenutno u redu cekanja {0}", QueueSize());

                File.Delete("buffer.json");
            }
        }

        [ExcludeFromCodeCoverage]
        public void SaveDataToJson()
        {
            Console.WriteLine("[SAVE] SAVING DATA");
            if (QueueSize() > 0)
            {
                string json = JsonConvert.SerializeObject(queue);
                if (File.Exists("buffer.json")) File.WriteAllText("buffer.json", json);
                Console.WriteLine("[SAVE] SAVE SUCCESSFULY");
            }
        }

        [ExcludeFromCodeCoverage]
        public void SnapshotJsonDataTemp()
        {
            Console.WriteLine("[SAVE] MAKING SNAPSHOT OF DATA");
            if (QueueSize() > 0)
            {
                string json = JsonConvert.SerializeObject(queue);
                File.WriteAllText("buffer.json", json);
                Console.WriteLine("[SAVE] SNAPSHOT MADE SUCCESSFULY");
            }
        }


        [ExcludeFromCodeCoverage]
        public List<ModelData> Queue { get; set; }

    }
}
