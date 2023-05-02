using Common;
using NUnit.Framework;
using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace Common_Testovi
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class Testovi
    {
        [Test]
        [TestCase()]
        public void ProveraKonekcijeKaBaziPodataka()
        {
            using (IDbConnection konekcija = Konekcija.GetConnection())
            {
                konekcija.Open();

                // Konekcija je otvorena
                Assert.NotNull(konekcija);
            }
        }

        [Test]
        [TestCase()]
        public void TestPodatak()
        {
            Podatak podatak = new Podatak();

            Assert.NotNull(podatak);
        }

        [Test]
        [TestCase(1, "uname", "addrr", "city", 1, 12, "Januar")]
        [TestCase(2, "uname", "addrr", "city", 3, 12, "Februar")]
        [TestCase(3, "uname", "addrr", "city", 4, 24, "Mart")]
        [TestCase(4, "name", "addrr", "city", 2, 12, "Januar")]
        public void TestPodatakParams(int rbr, string kime, string adr, string grad, int brojiloId, decimal potroseno, string mesec)
        {
            Podatak podatak = new Podatak(rbr, kime, adr, grad, brojiloId, potroseno, mesec);
            Assert.NotNull(podatak);
        }

        [Test]
        [TestCase(1, null, "addrr", "city", 1, 12, "Januar")]
        [TestCase(2, "uname", null, "city", 5, 12, "Februar")]
        [TestCase(3, "uname", "addrr", null, 4, 24, "Mart")]
        [TestCase(4, null, "addrr", null, 2, 12, "Januar")]
        [TestCase(5, "uname", null, null, 1, 152, "Januar")]
        public void TestPodatakParamsNull(int rbr, string kime, string adr, string grad, int brojiloId, decimal potroseno, string mesec)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Podatak podatak = new Podatak(rbr, kime, adr, grad, brojiloId, potroseno, mesec);

            });
        }

        [Test]
        [TestCase(1, "", "addrr", "city", 1, 12, "Januar")]
        [TestCase(2, "uname", "", "city", 3, 12, "Februar")]
        [TestCase(3, "uname", "addrr", "", 4, 24, "Mart")]
        [TestCase(4, "name", "addrr", "city", 2, 12, "")]
        public void TestPodatakEmptyParams(int rbr, string kime, string adr, string grad, int brojiloId, decimal potroseno, string mesec)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Podatak podatak = new Podatak(rbr, kime, adr, grad, brojiloId, potroseno, mesec);

            });
        }

        [Test]
        [TestCase()]
        public void PropertyTests()
        {
            Podatak podatak = new Podatak();

            podatak.Rbr = 1;
            podatak.KorisnickoIme = "test";
            podatak.Grad = "test";
            podatak.Adresa = "test";
            podatak.IdBrojila = 1;
            podatak.Mesec = "test";
            podatak.Potrosnja = 1;

            Assert.AreEqual(1, podatak.Rbr);
            Assert.AreEqual("test", podatak.KorisnickoIme);
            Assert.AreEqual("test", podatak.Grad);
            Assert.AreEqual("test", podatak.Adresa);
            Assert.AreEqual(1, podatak.IdBrojila);
            Assert.AreEqual("test", podatak.Mesec);
            Assert.AreEqual(1, podatak.Potrosnja);
        }

        [Test]
        [TestCase()]
        public void EqualsTestOk()
        {
            Podatak podatak = new Podatak();
            Podatak podatak2 = new Podatak();

            Assert.AreEqual(true, podatak.Equals(podatak2));
        }

        [Test]
        [TestCase()]
        public void EqualsTestFalse()
        {
            Podatak podatak = new Podatak();
            Podatak podatak2 = new Podatak();

            podatak.Grad = "test"; // vise nisu isti

            Assert.AreEqual(false, podatak.Equals(podatak2));
        }

        [Test]
        [TestCase()]
        public void HashCodeTest()
        {
            Podatak podatak = new Podatak();

            Assert.AreEqual(-300809437, podatak.GetHashCode());
        }
    }
}
