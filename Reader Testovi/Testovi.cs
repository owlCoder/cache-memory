using Common;
using Moq;
using NUnit.Framework;
using Reader;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Reader_Testovi
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class Testovi
    {
        [Test]
        [TestCase("mesec", "Januar")]
        [TestCase("rbr", "1")]
        [TestCase("korisnickoIme", "kime")]
        [TestCase("Februar", "mesec")]
        public void ProcitajServisOffline(string criteriaName, string criteria, bool all = false)
        {
            bool offline = true;

            try
            {
                IReader reader = new Reader.Reader();
                List<Podatak> podaci = reader.ProcitajPodatkeIzHistorical(criteriaName, criteria, all);
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
            IReader reader = new Reader.Reader();

            Assert.NotNull(reader);
        }

        [Test]
        [TestCase("", "")]
        public void MockObjekatOdredjeniPodaci(string critName, string crit)
        {
            Mock<IReader> reader = new Mock<IReader>();

            reader.Setup(p => p.ProcitajPodatkeIzHistorical(critName, crit, false)).Throws<InvalidOperationException>();
        }

        [Test]
        [TestCase("mesec", "Januar")]
        [TestCase("rbr", "1")]
        [TestCase("korisnickoIme", "kime")]
        [TestCase("Februar", "mesec")]
        public void MockObjekatSviPodaci(string critName, string crit)
        {
            Mock<IReader> reader = new Mock<IReader>();

            reader.Setup(p => p.ProcitajPodatkeIzHistorical(critName, crit, true)).Throws<InvalidOperationException>();
        }
    }
}
