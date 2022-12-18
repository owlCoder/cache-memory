using Cache_Memory.DataAccessObject.Implementations;

namespace Cache_Memory.Service
{
    public class RegistracijaNaSistemService
    {
        private static readonly IRegistracijaNaSistem registracija = new RegistracijaNaSistem();

        public bool Registracija(string username, string password, string adresa)
        {
            return registracija.RegistrujteSe(username, password, adresa);
        }
    }
}
