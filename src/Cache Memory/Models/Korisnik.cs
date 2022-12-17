using System;
using System.Collections.Generic;

namespace Cache_Memory.Models
{
    public class Korisnik
    {
        public Korisnik(int uid, string username, string password, string adresa)
        {
            // provera da li su null
            if (username == null || password == null || adresa == null)
            {
                throw new ArgumentNullException();
            }

            // provera da li su prazni stringovi
            if (username.Trim().Equals("") || password.Trim().Equals("") || adresa.Trim().Equals(""))
            {
                throw new ArgumentException();
            }

            // validni su parametri - podesi polja
            Uid = uid;
            Username = username;
            Password = password;
            Adresa = adresa;
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
