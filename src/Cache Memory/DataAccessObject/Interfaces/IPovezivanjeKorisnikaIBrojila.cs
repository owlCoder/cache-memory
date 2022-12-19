using Cache_Memory.Models;
using System.Collections.Generic;

namespace Cache_Memory.DataAccessObject.Interfaces
{
    public interface IPovezivanjeKorisnikaIBrojila : ICRUD<KorisnikBrojilo, int>
    {
        // metoda koja pronalazi sva brojila koja je registrovao jedan korisnik
        IEnumerable<KorisnikBrojilo> FindAllBrojilaPerUser(int userId);
    }
}
