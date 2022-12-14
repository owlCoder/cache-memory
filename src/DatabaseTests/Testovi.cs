using NUnit.Framework;
using Database;
using System;

namespace DatabaseTests
{
    [TestFixture]
    public class Testovi
    {
        public Testovi()
        {
            // prazan konstruktor
        }

        #region TESTOVI ZA KLASU KORISNIK
        // null argument exception
        [Test]
        [TestCase(null, null, null, null)]
        [TestCase(1, null, "Jovic", "Neznanih Junaka 2")]
        [TestCase(2, "Maja", null, null)]
        [TestCase(3, "Maja", "Jovic", null)]

        public void KorisnikNullParametar(int id, string username, string password, string adresa)
        {
            Assert.Throws<ArgumentNullException>(
               () =>
               {
                   Database.Modeli.Korisnik korisnik = new Database.Modeli.Korisnik(id, username, password, adresa);
               }
            );
        }

        // testovi koji trebaju proci
        [Test]
        [TestCase(1, "Maja", "Nulic", "Mise Antica 54a")]
        [TestCase(2, "Nela", "Jovic", "Neznanih Junaka 2")]
        [TestCase(3, "Dani", "Jovanic", "Ilin Gaj 3")]
        [TestCase(4, "Zen", "Lenic", "Trg 2")]

        public void KorisnikDobarParametar(int id, string username, string password, string adresa)
        {
            Database.Modeli.Korisnik korisnik = new Database.Modeli.Korisnik(id, username, password, adresa);

            Assert.AreEqual(korisnik.Uid, id);
            Assert.AreEqual(korisnik.Username, username);
            Assert.AreEqual(korisnik.Password, password);
            Assert.AreEqual(korisnik.Adresa, adresa);
        }

        // prazni stringovi
        // testovi koji trebaju proci
        [Test]
        [TestCase(1, "", "Nulic", "Mise Antica 54a")]
        [TestCase(2, "Nela", "", "Neznanih Junaka 2")]
        [TestCase(3, "Dani", "Jovanic", "")]
        [TestCase(4, "", "", "")]

        public void KorisnikPrazanParametar(int id, string username, string password, string adresa)
        {
            Assert.Throws<ArgumentException>(
               () =>
               {
                   Database.Modeli.Korisnik korisnik = new Database.Modeli.Korisnik(id, username, password, adresa);
               }
            );
        }

        // provera equals metode
        [Test]
        [TestCase(1, "Maja", "Nulic", "Mise Antica 54a")]
        [TestCase(2, "Nela", "Jovic", "Neznanih Junaka 2")]
        [TestCase(3, "Dani", "Jovanic", "Ilin Gaj 3")]
        [TestCase(4, "Zen", "Lenic", "Trg 2")]

        public void KorisnikEquals(int id, string username, string password, string adresa)
        {
            Database.Modeli.Korisnik korisnik = new Database.Modeli.Korisnik(id, username, password, adresa);
            Database.Modeli.Korisnik korisnikDrugi = new Database.Modeli.Korisnik(id, username, password, adresa);

            Assert.AreEqual(korisnik, korisnikDrugi);
        }
        #endregion

        #region TESTOVI ZA KLASU POTROSNJA
        // null argument exception
        [Test]
        [TestCase(1, 2, 2, null, 0)]
        [TestCase(1, 2, 2, null, 0)]
        [TestCase(1, 32, 2, null, 0)]
        [TestCase(4, 12, 10, null, 0)]

        public void PotrosnjaNullParametar(int uid, int bid, int mesec, string grad, double potroseno)
        {
            Assert.Throws<ArgumentNullException>(
               () =>
               {
                   Database.Modeli.Potrosnja potrosnja = new Database.Modeli.Potrosnja(uid, bid, mesec, grad, potroseno);
               }
            );
        }

        // testovi koji trebaju proci
        [Test]
        [TestCase(1, 4, 11, "Novi Sad", 12.41)]
        [TestCase(2, 21, 5, "Stari Sad", 4)]
        [TestCase(3, 10, 4, "Beograd", 6)]
        [TestCase(4, 4, 1, "Subotica", 2.5)]
        [TestCase(5, 3, 2, "Krusevac", 0.1)]

        public void PotrosnjaDobarParametar(int uid, int bid, int mesec, string grad, double potroseno)
        {
            Database.Modeli.Potrosnja potrosnja = new Database.Modeli.Potrosnja(uid, bid, mesec, grad, potroseno);

            Assert.AreEqual(potrosnja.UserId, uid);
            Assert.AreEqual(potrosnja.BrojiloId, bid);
            Assert.AreEqual(potrosnja.Mesec, mesec);
            Assert.AreEqual(potrosnja.Grad, grad);
            Assert.AreEqual(potrosnja.ZabelezenaPotrosnja, potroseno);
        }

        // provera equals metode
        [Test]
        [TestCase(1, 4, 11, "Novi Sad", 12.41)]
        [TestCase(2, 21, 5, "Stari Sad", 4)]
        [TestCase(3, 10, 4, "Beograd", 6)]
        [TestCase(4, 4, 1, "Subotica", 2.5)]
        [TestCase(5, 3, 2, "Krusevac", 0.1)]

        public void PotrosnjaEquals(int uid, int bid, int mesec, string grad, double potroseno)
        {
            Database.Modeli.Potrosnja potrosnja = new Database.Modeli.Potrosnja(uid, bid, mesec, grad, potroseno);
            Database.Modeli.Potrosnja potrosnjaDruga = new Database.Modeli.Potrosnja(uid, bid, mesec, grad, potroseno);

            Assert.AreEqual(potrosnja, potrosnjaDruga);
        }

        // unet je pogresan mesec
        [Test]
        [TestCase(1, -4, 11, "Novi Sad", 12.41)]
        [TestCase(2, 0, 5, "Stari Sad", 4)]
        [TestCase(3, 14, 4, "Beograd", 6)]
        [TestCase(4, -1, 1, "Subotica", 2.5)]
        [TestCase(5, 0, 2, "Krusevac", 0.1)]
        [TestCase(1, 0, 1, "Mall", 0.1)]

        public void PotrosnjaPogresanMesec(int uid, int bid, int mesec, string grad, double potroseno)
        {
            Database.Modeli.Potrosnja potrosnja = new Database.Modeli.Potrosnja(uid, bid, mesec, grad, potroseno);
            Database.Modeli.Potrosnja potrosnjaDruga = new Database.Modeli.Potrosnja(uid, bid, mesec, grad, potroseno);

            Assert.AreEqual(potrosnja, potrosnjaDruga);
        }

        #endregion
    }
}
