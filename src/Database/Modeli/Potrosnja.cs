using System;
using System.Collections.Generic;

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
        public override int GetHashCode()
        {
            int hashCode = -1775485255;
            hashCode = hashCode * -1521134295 + UserId.GetHashCode();
            hashCode = hashCode * -1521134295 + BrojiloId.GetHashCode();
            hashCode = hashCode * -1521134295 + Mesec.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Grad);
            hashCode = hashCode * -1521134295 + ZabelezenaPotrosnja.GetHashCode();
            return hashCode;
        }
    }
}
