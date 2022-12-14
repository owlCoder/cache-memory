using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Modeli
{
    public class Potrosnja
    {
        public int UserId { get; set; }
        public int BrojiloId { get; set; }
        public int Mesec { get; set; }
        public string Grad { get; set; }
        public double ZabelezenaPotrosnja { get; set; }
    }
}
