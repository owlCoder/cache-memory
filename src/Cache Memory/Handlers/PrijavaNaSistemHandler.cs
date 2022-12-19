using Cache_Memory.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache_Memory.Handlers
{
    public class PrijavaNaSistemHandler
    {
        private readonly static PrijavaNaSistemService prijavaNaSistemService = new PrijavaNaSistemService();

        public bool PrijavaHandle(string username, string password)
        {
            return prijavaNaSistemService.Prijava(username, password);
        }
    }
}
