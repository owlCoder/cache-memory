using Cache_Memory.Models;

namespace Cache_Memory.DataAccessObject.Interfaces
{
    public interface IKorisnici : ICRUD<Korisnik, int>
    {
        // metoda koja pronalazi da li postoji odredjeni red u tabeli za odredjenu kolonu tipa varchar
        bool ExistByAttributeString(string attribute, string attributeValue);

        // metoda koja pronalazzi da li postoji tacno odredjeni korisnik na osnovu atributa
        Korisnik FindByAttributeString(string attribute, string attributeValue);
        
        // metoda koja pronalazi najveci userId i vraca ga uvecanog za 1
        int FindMaxId();
    }
}
