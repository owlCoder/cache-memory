using System.Collections.Generic;
using UBP_Template.Models;

namespace UBP_Template.DAO.Interfaces
{
    public interface IKorisnici : ICRUD<Korisnik, int>
    {
        //List<Korisnik> FindAllKorisnici();
        int DeleteAllUsernameStarts(string username);

        // int PrebrojKorisnikeNoviSad();
    }
}
