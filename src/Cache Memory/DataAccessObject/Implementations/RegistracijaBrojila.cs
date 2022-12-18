using Cache_Memory.DataAccessObject.Interfaces;
using Cache_Memory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache_Memory.DataAccessObject.Implementations
{
    public class RegistracijaBrojila : IRegistracijaBrojila
    {
        private static readonly Brojila brojila = new Brojila();
        public bool RegistrujteBrojilo(string naziv)
        {
            int id = brojila.FindMaxId();

            Brojilo brojilo = new Brojilo(id, naziv);

            return brojila.Save(brojilo) == 1;
        }
    }
}
