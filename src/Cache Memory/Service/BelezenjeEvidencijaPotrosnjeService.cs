using Cache_Memory.DataAccessObject.Implementations;
using Cache_Memory.DataAccessObject.Interfaces;
using Cache_Memory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Cache_Memory.Service
{
    public class BelezenjeEvidencijaPotrosnjeService
    {
        private static readonly IBelezenjeEvidencijaPotrosnje belezenjeEvidencije = new BelezenjeEvidencijaPotrosnje();

        public List<EvidencijaPotrosnje> GetEvidencijaAll()
        {
            return belezenjeEvidencije.FindAll().ToList();
        }

        public List<EvidencijaPotrosnje> GetEvidencijaByMesec(int mesec)
        {
            return belezenjeEvidencije.FindByMesec(mesec).ToList();
        }

        public List<EvidencijaPotrosnje> GetEvidencijaByUserId(int userId)
        {
            return belezenjeEvidencije.FindByUserId(userId).ToList();
        }

        public List<EvidencijaPotrosnje> GetEvidencijaByGrad(string grad)
        {
            return belezenjeEvidencije.FindByGrad(grad).ToList();
        }
    }
}
