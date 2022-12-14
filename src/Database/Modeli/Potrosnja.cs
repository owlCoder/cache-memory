using System;

namespace Database.Modeli
{
    public class Potrosnja
    {
        public Potrosnja(int userId, int brojiloId, int mesec, string grad, double zabelezenaPotrosnja)
        {
            UserId = userId;
            BrojiloId = brojiloId;
            Mesec = mesec;
            Grad = grad ?? throw new ArgumentNullException(nameof(grad));
            ZabelezenaPotrosnja = zabelezenaPotrosnja;
        }

        public int UserId { get; set; }
        public int BrojiloId { get; set; }
        public int Mesec { get; set; }
        public string Grad { get; set; }
        public double ZabelezenaPotrosnja { get; set; }
        public override bool Equals(object obj)
        {
            return obj is Potrosnja potrosnja &&
                   UserId == potrosnja.UserId &&
                   BrojiloId == potrosnja.BrojiloId &&
                   Mesec == potrosnja.Mesec &&
                   Grad == potrosnja.Grad &&
                   ZabelezenaPotrosnja == potrosnja.ZabelezenaPotrosnja;
        }
    }
}
