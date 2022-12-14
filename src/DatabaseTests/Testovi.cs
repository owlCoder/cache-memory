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
    }
}
