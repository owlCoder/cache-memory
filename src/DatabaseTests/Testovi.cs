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
    }
}
