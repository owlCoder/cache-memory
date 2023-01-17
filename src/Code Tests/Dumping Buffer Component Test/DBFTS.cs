using Common_Class_Library.Implementations;
using DumpingBuffer_Component.Implementations;
using Historical_Component.Implementations;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Remoting;

namespace Dumping_Buffer_Component_Test
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class DBFTS
    {
        [Test]
        [TestCase()]
        public void DBCConstOk()
        {
            DumpingBuffer dumpingBuffer = new DumpingBuffer();

            Assert.NotNull(dumpingBuffer);
        }

        [Test]
        [TestCase()]
        public void DBCCount()
        {
            DumpingBuffer dumpingBuffer = new DumpingBuffer();

            int size = dumpingBuffer.QueueSize();
            Assert.Zero(size);
        }

        [Test]
        [TestCase()]
        public void DBCAddQueue()
        {
            DumpingBuffer dumpingBuffer = new DumpingBuffer();
            ModelData model = new ModelData();

            dumpingBuffer.AddToQueue(model);

            Assert.AreEqual(1, dumpingBuffer.QueueSize());
        }

        [Test]
        [TestCase()]
        public void DBCAddQueueSameObject()
        {
            DumpingBuffer dumpingBuffer = new DumpingBuffer();
            ModelData model = new ModelData();

            dumpingBuffer.AddToQueue(model);
            dumpingBuffer.AddToQueue(model); // dodavanje istog objekta ne sme da poveca queue

            Assert.AreEqual(1, dumpingBuffer.QueueSize());
        }

        [Test]
        [TestCase()]
        public void DBCAddQueueFullQueue()
        {
            DumpingBuffer dumpingBuffer = new DumpingBuffer();
            List<ModelData> models = new List<ModelData>();

            for (int i = 0; i < 7; i++)
            {
                models.Add(new ModelData(i + 10, "UNAME", "ADDR", "CITY", "SE-12", 1 + i, "Januar"));
            }

            foreach (ModelData m in models)
            {
                dumpingBuffer.AddToQueue(m);
            }

            Assert.AreEqual(7, dumpingBuffer.QueueSize());
        }

        [Test]
        [TestCase()]
        public void DBCEmptyQueueFullQueue()
        {
            DumpingBuffer dumpingBuffer = new DumpingBuffer();
            List<ModelData> models = new List<ModelData>();

            for (int i = 0; i < 18; i++)
            {
                models.Add(new ModelData(i + 10, "UNAME", "ADDR", "CITY", "SE-12", 1 + i, "Januar"));
            }

            foreach (ModelData m in models)
            {
                dumpingBuffer.AddToQueue(m);
            }

            for (int i = 0; i < 18; i++)
            {
                dumpingBuffer.RemoveFromQueue();
            }

            Assert.AreEqual(0, dumpingBuffer.QueueSize());
        }

        [Test]
        [TestCase()]
        public void DBCSendDataHistorical()
        {
            DumpingBuffer dumpingBuffer = new DumpingBuffer();
            dumpingBuffer.AddToQueue(new ModelData(15, "UNAME", "ADDR", "CITY", "SE-12", 10, "Januar"));
            bool result = dumpingBuffer.SendDataToDatabase(RemotingServices.Connect(typeof(Historical), "tcp://localhost:8090/Historical") as Historical);

            Assert.AreEqual(false, result);
        }

        [Test]
        [TestCase()]
        public void DBCSendDataHistoricalMulti()
        {
            DumpingBuffer dumpingBuffer = new DumpingBuffer();
            bool result = false;

            try
            {
                for (int i = 1; i <= 10; i++)
                {
                    dumpingBuffer.AddToQueue(new ModelData(15 + i, "UNAME", "ADDR", "CITY", "SE-12", 10, "Januar"));
                    result = dumpingBuffer.SendDataToDatabase(RemotingServices.Connect(typeof(Historical), "tcp://localhost:8090/Historical") as Historical);
                }
            }
            catch
            {
                Console.WriteLine("[ERROR] CONNECTION TO SERVER FAILED");
            }
            
            Assert.AreEqual(false, result);
        }
    }
}
