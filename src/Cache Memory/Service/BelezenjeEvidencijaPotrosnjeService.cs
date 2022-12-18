using Cache_Memory.DataAccessObject.Implementations;
using Cache_Memory.DataAccessObject.Interfaces;
using Cache_Memory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache_Memory.Service
{
    public class BelezenjeEvidencijaPotrosnjeService
    {
        private static readonly IBelezenjeEvidencijaPotrosnje belezenjeEvidencije = new BelezenjeEvidencijaPotrosnje();

        List<EvidencijaPotrosnje> GetEvidencijaAll()
        {
            return belezenjeEvidencije.FindAll().ToList();
        }

        List<EvidencijaPotrosnje> GetEvidencijaByMesec(int mesec)
        {
            return belezenjeEvidencije.FindByMesec(mesec).ToList();
        }

        List<EvidencijaPotrosnje> GetEvidencijaByUserId(int userId)
        {
            return belezenjeEvidencije.FindByUserId(userId).ToList();
        }

        List<EvidencijaPotrosnje> GetEvidencijaByGrad(string grad)
        {
            return belezenjeEvidencije.FindByGrad(grad).ToList();
        }
    }
}
