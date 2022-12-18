namespace Cache_Memory.DataAccessObject.Implementations
{
    public interface IRegistracijaNaSistem
    {
        bool RegistrujteSe(string username, string password, string adresa);
    }
}