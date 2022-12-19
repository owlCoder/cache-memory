using Cache_Memory.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache_Memory.Handlers
{
    public class RegistracijaNaSistemHandler
    {
        private static readonly RegistracijaNaSistemService registracijaNaSistemService = new RegistracijaNaSistemService();

        public bool RegistracijaHandle(string username, string password, string adresa)
        {
            return registracijaNaSistemService.Registracija(username, password, adresa);
        }
    }
}
