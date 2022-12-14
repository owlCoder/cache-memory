using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Modeli
{
    public class Korisnik
    {
        public int Uid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Adresa { get; set; }
    }
}
