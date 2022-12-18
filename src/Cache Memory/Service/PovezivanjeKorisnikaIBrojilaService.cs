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
    public class PovezivanjeKorisnikaIBrojilaService
    {
        private static readonly IPovezivanjeKorisnikaIBrojila ipk = new PovezivanjeKorisnikaIBrojila();

        public List<KorisnikBrojilo> FindAllBrojilaPoKorisniku(int userId)
        {
            return ipk.FindAllBrojilaPerUser(userId).ToList();
        }

        public bool PovezivanjeKorisnikaIBrojila(KorisnikBrojilo entity)
        {
            return ipk.Save(entity) == 1; // dodaje se jedno brojilo, 1 je dodato, ostalo greska
        }
    }
}
