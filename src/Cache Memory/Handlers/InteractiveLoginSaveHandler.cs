using Cache_Memory.DataTransferObject.TrenutniKorisnik;
using Cache_Memory.Models;
using Cache_Memory.Service;

namespace Cache_Memory.Handlers
{
    public class InteractiveLoginSaveHandler
    {
        private static readonly KorisniciService korisniciService = new KorisniciService();
        public static void SetAuthState(string enteredUsername)
        {
            Korisnik current = korisniciService.GetCurrentUser("username", enteredUsername);
            PrijavljeniKorisnik.TrenutniKorisnik = current;
        }
    }
}
