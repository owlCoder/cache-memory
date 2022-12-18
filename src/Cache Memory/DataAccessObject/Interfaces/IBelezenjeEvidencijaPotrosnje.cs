using Cache_Memory.Models;
using System.Collections.Generic;

namespace Cache_Memory.DataAccessObject.Interfaces
{
    public interface IBelezenjeEvidencijaPotrosnje : ICRUD<EvidencijaPotrosnje, int>
    {
        // metoda koja pronalazi potrosnju za odredjeni mesec
        IEnumerable<EvidencijaPotrosnje> FindByMesec(int mesec);

        // metoda koja pronalazi potrosnje za odredjenog korisnika
        IEnumerable<EvidencijaPotrosnje> FindByUserId(int id);

        // metoda koja pronalazi potrosnje za odredjeni grad
        IEnumerable<EvidencijaPotrosnje> FindByGrad(string grad);

    }
}
