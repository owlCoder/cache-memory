using Common;
using Historical;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Historical_Testovi
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class Testovi
    {
        [Test]
        [TestCase()]
        public void SviPodaci()
        {
            Historical.Historical hc = new Historical.Historical();

            Assert.DoesNotThrow(() =>
            {
                List<Podatak> list = hc.SviPodaciIzBazePodataka().ToList();
            });
        }

        [Test]
        [TestCase("rbr", "12")]
        [TestCase("korisnickoIme", "user")]
        [TestCase("adresa", "Trg Dositeja Obradovica 6")]
        [TestCase("grad", "Novi Sad")]
        [TestCase("idBrojila", "1")]
        [TestCase("potrosnja", "321")]
        [TestCase("mesec", "Januar")]
        public void PodaciPoKriterijumu(string criteria, string value)
        {
            Historical.Historical hc = new Historical.Historical();

            Assert.DoesNotThrow(() =>
            {
                List<Podatak> list = hc.OdredjeniPodaciIzBazePodataka(criteria, value).ToList();
            });
        }

        [Test]
        [TestCase(1, "uname", "addrr", "city", 4, 12, "Januar")]
        [TestCase(2, "uname", "addrr", "city", 4, 12, "Februar")]
        [TestCase(3, "uname", "addrr", "city", 4, 24, "Mart")]
        [TestCase(4, "name", "addrr", "city", 4, 12, "Januar")]
        [TestCase(5, "uname", "addrr", "city", 3, 152, "Januar")]
        public void MockUpisUBazu(int userID, string username, string userAddress, string userCity, int brojiloId, decimal potroseno, string mesec)
        {
            Mock<IHistorical> mock = new Mock<IHistorical>();

            mock.Setup(p => p.UpisPodatkaUBazuPodataka(new Podatak(userID, username, userAddress, userCity, brojiloId, potroseno, mesec))).Returns(0);
        }
    }
}
