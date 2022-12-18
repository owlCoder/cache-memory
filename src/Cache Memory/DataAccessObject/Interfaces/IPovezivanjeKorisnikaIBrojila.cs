using Cache_Memory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache_Memory.DataAccessObject.Interfaces
{
    public interface IPovezivanjeKorisnikaIBrojila : ICRUD<KorisnikBrojilo, int>
    {
        // metoda koja pronalazi sva brojila koja je registrovao jedan korisnik
        IEnumerable<KorisnikBrojilo> FindAllBrojilaPerUser(int userId);
    }
}
