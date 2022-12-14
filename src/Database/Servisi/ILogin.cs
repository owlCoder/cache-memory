namespace Database.Servisi
{
    public interface ILogin
    {
        // Prijava korisnika sa odredjenim kreditijalima
        bool LogIn(string username, string password);
    }
}
