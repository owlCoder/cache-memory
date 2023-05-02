using Common;
using Moq;
using NUnit.Framework;
using System;
using System.Diagnostics.CodeAnalysis;
using Writer;

namespace Writer_Testovi
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class Testovi
    {
        [Test]
        [TestCase()]
        public void NijeNullObjekat()
        {
            IWriter writer = new Writer.Writer();
            Assert.NotNull(writer);
        }

        [Test]
        [TestCase(1, "uname", "addrr", "city", 1, 12, "Januar")]
        [TestCase(2, "uname", "addrr", "city", 3, 12, "Februar")]
        [TestCase(3, "uname", "addrr", "city", 4, 24, "Mart")]
        [TestCase(4, "name", "addrr", "city", 2, 12, "Januar")]
        public void ProcitajServisOffline(int rbr, string kime, string adr, string grad, int brojiloId, decimal potroseno, string mesec)
        {
            bool offline = true;
            Podatak podatak = new Podatak(rbr, kime, adr, grad, brojiloId, potroseno, mesec);

            try
            {
                IWriter writer = new Writer.Writer();
                bool uspesno = writer.ProsledjivanjePodatkaNaDumpingBuffer(podatak);
                offline = false;
            }
            catch (InvalidOperationException)
            {
                offline = true;
                Console.WriteLine("Servis nije operativan!");
            }

            Assert.IsTrue(offline); // servis nije dostupan jer prethodno nije pokrenut
        }

        [Test]
        public void ObjekatNijeNull()
        {
            IWriter writer = new Writer.Writer();

            Assert.NotNull(writer);
        }

        [TestCase(1, "uname", "addrr", "city", 1, 12, "Januar")]
        [TestCase(2, "uname", "addrr", "city", 3, 12, "Februar")]
        [TestCase(3, "uname", "addrr", "city", 4, 24, "Mart")]
        [TestCase(4, "name", "addrr", "city", 2, 12, "Januar")]
        public void MockObjekatOdredjeniPodaci(int rbr, string kime, string adr, string grad, int brojiloId, decimal potroseno, string mesec)
        {
            Mock<IWriter> reader = new Mock<IWriter>();

            reader.Setup(p => p.ProsledjivanjePodatkaNaDumpingBuffer(new Podatak(rbr, kime, adr, grad, brojiloId, potroseno, mesec))).Throws<InvalidOperationException>();
        }
    }
}
