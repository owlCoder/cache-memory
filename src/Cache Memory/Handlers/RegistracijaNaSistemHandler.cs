using Cache_Memory.Service;

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
