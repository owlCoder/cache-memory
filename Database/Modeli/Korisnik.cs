using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Modeli
{
    public class Korisnik
    {
        public Korisnik(int uid, string username, string password, string adresa)
        {
            Uid = uid;
            Username = username ?? throw new ArgumentNullException(nameof(username));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            Adresa = adresa ?? throw new ArgumentNullException(nameof(adresa));
        }

        public int Uid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Adresa { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Korisnik korisnik &&
                   Uid == korisnik.Uid &&
                   Username == korisnik.Username &&
                   Password == korisnik.Password &&
                   Adresa == korisnik.Adresa;
        }

        public override int GetHashCode()
        {
            int hashCode = -201515749;
            hashCode = hashCode * -1521134295 + Uid.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Username);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Password);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Adresa);
            return hashCode;
        }
    }
}
