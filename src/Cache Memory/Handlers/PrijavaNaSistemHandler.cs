using Cache_Memory.Service;

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
