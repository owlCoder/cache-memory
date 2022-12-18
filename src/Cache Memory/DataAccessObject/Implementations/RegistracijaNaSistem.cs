using Cache_Memory.Models;

namespace Cache_Memory.DataAccessObject.Implementations
{
    public class RegistracijaNaSistem : IRegistracijaNaSistem
    {
        private static readonly Korisnici korisnici = new Korisnici();

        public bool RegistrujteSe(string username, string password, string adresa)
        {
            if (korisnici.FindByAttributeString("username", username) != null)
            {
                // korisnik je registrovan
                return false;
            }
            else
            {
                // registracija novog korisnika
                int idGenerator = korisnici.FindMaxId();

                Korisnik novi = new Korisnik(idGenerator, username, password, adresa);
                int rowsAffected = korisnici.Save(novi);

                return rowsAffected == 1; // dodat je tacno jedan korisnik, u suprotnom nije dodat
            }
        }
    }
}
