using Cache_Memory.DataAccessObject.Interfaces;
using Cache_Memory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache_Memory.DataAccessObject.Implementations
{
    public class PrijavaNaSistem : IPrijavaNaSistem
    {
        private static readonly Korisnici korisnici = new Korisnici();
        private static Korisnik trenutniKorisnik = null;

        public bool PrijaviteSe(string username, string password)
        {
            // proveri da li korisnik postoji u bazi podataka
            bool postoji = korisnici.ExistByAttributeString("username", username);

            if(postoji)
            {
                // proveri da li se sifre poklapaju
                trenutniKorisnik = korisnici.FindByAttributeString("password", password);

                return trenutniKorisnik != null;
            }
            else
            {
                return false; // korisnik ne postoji
            }
        }

        public static Korisnik TrenutniKorisnik { get => trenutniKorisnik; set => trenutniKorisnik = value; }
    }
}
