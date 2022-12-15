using NUnit.Framework;
using System;
using System.Data;

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

        #region TESTOVI ZA KREIRANJE KONEKCIJE KA BAZI PODATAKA
        // vraca postojecu konekciju
        [Test]
        [TestCase()]
        public void DobraKonekcija()
        {
            IDbConnection statusKonekcije = Database.Konekcija.CreateDatabaseConnection.GetConnection();

            Assert.NotNull(statusKonekcije);
        }
        #endregion

        #region TESTIRANJE PUSHDATA KLASE
        // los upit - treba da vrati -1
        [Test]
        [TestCase("SELECT *FROM UNKNOW_TABLE")]
        [TestCase("INSERT INTO UNKNOW_TABLE")]
        [TestCase("INSERT INTO UNKNOW_TABLE VALUES")]
        [TestCase("INSERT INTO KORISNICI VALUES(5, 4)")]
        public void BadQuery(string sql)
        {
            Database.Servisi.PushData toSend = new Database.Servisi.PushData();
            int result = toSend.ExecuteNonQuery(sql);

            Assert.AreEqual(-2, result);
        }

        // dobri upiti vraca broj ubacenih/obrisanih redova u tabelu (1 red po test case)
        [Test]
        [TestCase("INSERT INTO KORISNICI VALUES(20, 'dani', 'sifra', 'Alekse Santica 4')")]
        [TestCase("INSERT INTO KORISNICI VALUES(21, 'hannalam', 'lammaana', 'Trg 12')")]
        [TestCase("DELETE FROM KORISNICI WHERE USERID = 20")]
        [TestCase("DELETE FROM KORISNICI WHERE USERID = 21")]
        public void CorrectQuery(string sql)
        {
            Database.Servisi.PushData toSend = new Database.Servisi.PushData();
            int result = toSend.ExecuteNonQuery(sql);

            Assert.AreEqual(1, result); // jedan red je dodat/obrisan
        }
        #endregion

        #region TESTIRANJE USERLOGIN KLASE
        // login nepostojeceg korisnika
        [Test]
        [TestCase("dani", "sifra")]
        [TestCase("user", "sifra")]
        [TestCase("123", "sifra")]
        [TestCase("dani", "123")]
        public void NepostojeciKorisnik(string username, string password)
        {
            Database.Servisi.UserLogin prijava = new Database.Servisi.UserLogin();
            bool prijavaUspesna = prijava.LogIn(username, password);

            Assert.AreEqual(false, prijavaUspesna);
        }

        // kreiranje i login postojeceg korisnika
        [Test]
        [TestCase("dani", "sifra")]
        [TestCase("user", "sifra")]
        public void PostojeciKorisnik(string username, string password)
        {
            // kreiranje privremenog korisnika
            Database.Servisi.PushData phd = new Database.Servisi.PushData();
            phd.ExecuteNonQuery("INSERT INTO KORISNICI VALUES(100, '" + username + "', '" + password + "', 'Alekse Santica 4')");

            // prijava korisnika
            Database.Servisi.UserLogin prijava = new Database.Servisi.UserLogin();
            bool prijavaUspesna = prijava.LogIn(username, password);

            Assert.AreEqual(true, prijavaUspesna);

            // brisanje dodatog korisnika
            phd.ExecuteNonQuery("DELETE FROM KORISNICI WHERE USERID = 100");
        }
        #endregion

        #region TESTIRANJE USERREGISTER KLASE
        // registracija novog korisnika
        [Test]
        [TestCase("dani", "sifra2", "adresa")]
        [TestCase("user", "sifra1", "neka adresa")]
        [TestCase("admin", "admin1", "ftn")]
        public void RegistracijaNovogKorisnika(string username, string password, string adresa)
        {
            // kreiranje privremenog korisnika
            Database.Servisi.PushData phd = new Database.Servisi.PushData();

            Database.Servisi.UserRegister registracija = new Database.Servisi.UserRegister();
            bool registracijaUspesna = registracija.Register(username, password, adresa);

            Assert.AreEqual(true, registracijaUspesna);

            // brisanje kreiranih korisnika
            phd.ExecuteNonQuery("DELETE FROM KORISNICI WHERE USERNAME = '" + username + "'");
        }

        // registracija postojeceg korisnika - ne sme da prodje jer je username unique
        [Test]
        [TestCase("dani", "sifra", "ftn")]
        [TestCase("user", "sifra", "adresa")]
        public void RegistracijaPostojeciKorisnik(string username, string password, string adresa)
        {
            Database.Servisi.UserRegister registracija = new Database.Servisi.UserRegister();
            registracija.Register(username, password, adresa);
            bool registracijaUspesna = registracija.Register(username, password, adresa);

            Assert.AreEqual(false, registracijaUspesna);

            // brisanje dodatog korisnika
            Database.Servisi.PushData phd = new Database.Servisi.PushData();
            phd.ExecuteNonQuery("DELETE FROM KORISNICI WHERE USERNAME = '" + username + "'");
        }
        #endregion

        #region TESTIRANJE PULLBROJILODATA KLASE

        #endregion

        #region TESTIRANJE USERREGISTERBROJILO KLASE

        #endregion

        #region TESTIRANJE BROJILO KLASE
        // testovi koji trebaju da prodju
        [Test]
        [TestCase (1, "SE-52145")]
        [TestCase(2, "SE-52214")]
        [TestCase(3, "SE-632121")]
        [TestCase(4, "SE-448952")]
        [TestCase(5, "SE-22644")]
        public void BrojiloKorektniTestovi(int id, string naziv)
        {
            Database.Modeli.Brojilo brojilo = new Database.Modeli.Brojilo(id, naziv);

            Assert.AreEqual(id, brojilo.Id);
            Assert.AreEqual(naziv, brojilo.Naziv);
        }

        // testovi koji vracaju null argument exception
        [Test]
        [TestCase(1, null)]
        [TestCase(2, null)]
        public void BrojiloNullTestovi(int id, string naziv)
        {
            Assert.Throws<ArgumentNullException>(
              () =>
              {
                  Database.Modeli.Brojilo brojilo = new Database.Modeli.Brojilo(id, naziv);
              }
           );
        }
        [Test]
        [TestCase(1, "")]
        [TestCase(2, "")]
        public void BrojiloWrongArgumentTestovi(int id, string naziv)
        {
            Assert.Throws<ArgumentException>(
              () =>
              {
                  Database.Modeli.Brojilo brojilo = new Database.Modeli.Brojilo(id, naziv);
              }
           );
        }
        #endregion
    }
}
