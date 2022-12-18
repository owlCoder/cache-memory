using Cache_Memory.Models;
using Cache_Memory.DataAccessObject.Interfaces;
using Cache_Memory.DataAccessObject.Implementations;

namespace Cache_Memory.Service
{
    public class PrijavaNaSistemService
    {
        private static readonly IPrijavaNaSistem prijavaNaSistem = new PrijavaNaSistem();

        public bool Prijava(string username, string password)
        {
            return prijavaNaSistem.PrijaviteSe(username, password);
        }
    }
}
