using UBP_Template.UI;

namespace UBP_Template
{
    class Program
    {
        private static readonly KorisniciServiceHandler meniKorisnici = new KorisniciServiceHandler();
        static void Main()
        {
            meniKorisnici.MeniKorisnici();
        }
    }
}
