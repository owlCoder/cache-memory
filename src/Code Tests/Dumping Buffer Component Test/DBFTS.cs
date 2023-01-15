using Common_Class_Library.Implementations;
using DumpingBuffer_Component.Implementations;
using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

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

            for (int i = 0; i < 7; i++)
            {
                models.Add(new ModelData(i + 10, "UNAME", "ADDR", "CITY", "SE-12", 1 + i, "Januar"));
            }

            foreach (ModelData m in models)
            {
                dumpingBuffer.AddToQueue(m);
            }

            for (int i = 0; i < 7; i++)
            {
                dumpingBuffer.RemoveFromQueue();
            }

            Assert.AreEqual(0, dumpingBuffer.QueueSize());
        }


    }
}
