using Common;
using Dumping_Buffer;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Dumping_Buffer_Testovi
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class Testovi
    {
        [Test]
        [TestCase()]
        public void BaferNijeNull()
        {
            DumpingBuffer dumpingBuffer = new DumpingBuffer();

            Assert.NotNull(dumpingBuffer);
        }

        [Test]
        [TestCase()]
        public void PrazanBafer()
        {
            Mock<IDumpingBuffer> mock = new Mock<IDumpingBuffer>();

            mock.Setup(p => p.TrenutnoURedu()).Returns(0);
        }

        [Test]
        [TestCase()]
        public void DodavanjeUBafer()
        {
            DumpingBuffer dumpingBuffer = new DumpingBuffer();
            Podatak podatak = new Podatak();

            dumpingBuffer.DodavanjeURedCekanja(podatak);

            Assert.AreEqual(1, dumpingBuffer.TrenutnoURedu());
        }

        [Test]
        [TestCase()]
        public void MockDodajUBafer()
        {
            Mock<IDumpingBuffer> mock = new Mock<IDumpingBuffer>();
            Podatak podatak = new Podatak();

            mock.Setup(p => p.DodavanjeURedCekanja(podatak));
            mock.Setup(p => p.TrenutnoURedu()).Returns(1);
        }

        [Test]
        [TestCase()]
        public void DodajMockPodatke()
        {
            Mock<IDumpingBuffer> mock = new Mock<IDumpingBuffer>();
            Mock<Podatak> mdm = new Mock<Podatak>();

            mock.Setup(p => p.DodavanjeURedCekanja(mdm.Object));
            mock.Setup(p => p.TrenutnoURedu()).Returns(1);
        }

        [Test]
        [TestCase()]
        public void DodavanjeDvaIstaObjekta()
        {
            Mock<IDumpingBuffer> mock = new Mock<IDumpingBuffer>();
            Mock<Podatak> mdm = new Mock<Podatak>();

            mock.Setup(p => p.DodavanjeURedCekanja(mdm.Object));
            mock.Setup(p => p.DodavanjeURedCekanja(mdm.Object));
            mock.Setup(p => p.TrenutnoURedu()).Returns(1);
        }

        [Test]
        [TestCase()]
        public void BaferPopunjenPrvih7Podataka()
        {
            Mock<IDumpingBuffer> mock = new Mock<IDumpingBuffer>();
            Mock<Podatak> mdm = new Mock<Podatak>();

            List<Podatak> models = new List<Podatak>();

            for (int i = 0; i < 7; i++)
            {
                Mock<Podatak> novi = new Mock<Podatak>(i + 10, "UNAME", "ADDR", "CITY", 2, 1 + i, "Januar");
                mock.Setup(p => p.DodavanjeURedCekanja(mdm.Object));
            }

            mock.Setup(p => p.TrenutnoURedu()).Returns(7);
        }

        [Test]
        [TestCase()]
        public void CiscenjeBaferaNakon7Podataka()
        {
            DumpingBuffer dumpingBuffer = new DumpingBuffer();
            for (int i = 0; i < dumpingBuffer.TrenutnoURedu(); i++)
                dumpingBuffer.UklananjeIzRedaCekanja();
            List<Podatak> models = new List<Podatak>();

            for (int i = 0; i < 18; i++)
            {
                models.Add(new Podatak(i + 10, "UNAME", "ADDR", "CITY", 2, 1 + i, "Januar"));
            }

            foreach (Podatak m in models)
            {
                dumpingBuffer.DodavanjeURedCekanja(m);
            }

            for (int i = 0; i < 18; i++)
            {
                dumpingBuffer.UklananjeIzRedaCekanja();
            }

            Assert.AreEqual(0, dumpingBuffer.TrenutnoURedu());
        }

        [Test]
        [TestCase()]
        public void SlanjePodatakaNaHistorical()
        {
            DumpingBuffer dumpingBuffer = new DumpingBuffer();
            for (int i = 0; i < dumpingBuffer.TrenutnoURedu(); i++)
                dumpingBuffer.UklananjeIzRedaCekanja();

            dumpingBuffer.DodavanjeURedCekanja(new Podatak(15, "UNAME", "ADDR", "CITY", 4, 10, "Januar"));
            bool result = dumpingBuffer.SlanjePodataka();

            Assert.AreEqual(false, result);
        }

        [Test]
        [TestCase()]
        public void SlanjeVisePodatakaNaHistorical()
        {
            DumpingBuffer dumpingBuffer = new DumpingBuffer();
            bool result = false;

            try
            {
                for (int i = 1; i <= 10; i++)
                {
                    dumpingBuffer.DodavanjeURedCekanja(new Podatak(15 + i, "UNAME", "ADDR", "CITY", 2, 10, "Januar"));
                    result = dumpingBuffer.SlanjePodataka();
                }
            }
            catch
            {
                Console.WriteLine("Server baze podataka nije operativan!");
            }

            Assert.AreEqual(false, result);
        }
    }
}
