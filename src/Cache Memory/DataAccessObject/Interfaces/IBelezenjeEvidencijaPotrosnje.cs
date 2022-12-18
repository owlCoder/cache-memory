using Cache_Memory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
