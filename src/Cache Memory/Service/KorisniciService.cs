using Cache_Memory.DataAccessObject.Implementations;
using Cache_Memory.DataAccessObject.Interfaces;
using Cache_Memory.Models;

namespace Cache_Memory.Service
{
    public class KorisniciService
    {
        private static readonly IKorisnici korisnici = new Korisnici(); 
        public Korisnik GetCurrentUser(string type, string username)
        {
            return korisnici.FindByAttributeString(type, username);
        }
    }
}
