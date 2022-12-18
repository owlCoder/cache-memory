using Cache_Memory.Models;

namespace Cache_Memory.DataTransferObject.TrenutniKorisnik
{
    public class PrijavljeniKorisnik
    {
        private static Korisnik trenutniKorisnik = null;

        public static Korisnik TrenutniKorisnik { get => trenutniKorisnik; set => trenutniKorisnik = value; }
    }
}
