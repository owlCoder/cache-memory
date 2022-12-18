using Cache_Memory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache_Memory.DataTransferObject.TrenutniKorisnik
{
    public class PrijavljeniKorisnik
    {
        private static Korisnik trenutniKorisnik = null;

        public static Korisnik TrenutniKorisnik { get => trenutniKorisnik; set => trenutniKorisnik = value; }
    }
}
