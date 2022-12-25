using System.Collections.Generic;
using UBP_Template.DAO.Interfaces;
using UBP_Template.Models;

namespace UBP_Template.Services
{
    public class KorisniciService
    {
        private static readonly IKorisnici korisnici = new DAO.Implementations.Korisnici();

        public IEnumerable<Korisnik> GetAllKorisnici()
        {
            return korisnici.FindAll();
        }

        public Korisnik GetExactKorisnici(int id)
        {
            return korisnici.FindById(id);
        }

        public int GetBrojSvihKorisnika()
        {

            return korisnici.Count();
        }

        public int DeleteById(int userId)
        {
            return korisnici.DeleteById(userId);
        }

        public int DeleteBy(Korisnik entity)
        {
            return korisnici.Delete(entity);
        }

        public int DeleteStartBy(string username)
        {
            return korisnici.DeleteAllUsernameStarts(username);
        }

        public bool ExistById(int id)
        {
            return korisnici.ExistById(id);
        }

        public int Save(Korisnik entity)
        {
            return korisnici.Save(entity);
        }
    }
}
