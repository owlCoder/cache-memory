using System.Collections.Generic;

namespace UBP_Template.Models
{
    public class Korisnik
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Adresa { get; set; }

        public Korisnik(int userId, string username, string password, string adresa)
        {
            UserId = userId;
            Username = username;
            Password = password;
            Adresa = adresa;
        }
        public override bool Equals(object obj)
        {
            return obj is Korisnik korisnici &&
                   UserId == korisnici.UserId &&
                   Username == korisnici.Username &&
                   Password == korisnici.Password &&
                   Adresa == korisnici.Adresa;
        }
        public override int GetHashCode()
        {
            int hashCode = 1267785437;
            hashCode = hashCode * -1521134295 + UserId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Username);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Password);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Adresa);
            return hashCode;
        }

        public static string GetFormatedHeader()
        {
            return string.Format("{0, -10} {1, -15} {2, -15} {3, -25}", "User_Id", "Username", "Password", "Adresa");
        }
        public override string ToString()
        {
            return string.Format("{0, -10} {1, -15} {2, -15} {3, -25}", UserId, Username, Password, Adresa);
        }
    }
}
