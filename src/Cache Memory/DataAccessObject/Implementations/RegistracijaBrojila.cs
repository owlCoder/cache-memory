using Cache_Memory.DataAccessObject.Interfaces;
using Cache_Memory.Models;

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
