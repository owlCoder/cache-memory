using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache_Memory.Models
{
    public class EvidencijaPotrosnje
    {
        public EvidencijaPotrosnje(int userId, int brojiloId, int mesec, string grad, double zabelezenaPotrosnja)
        {
            UserId = userId;
            BrojiloId = brojiloId;

            // mesec ne moze biti negativan ili preko 12
            if (mesec < 1 && mesec > 12)
            {
                throw new ArgumentException();
            }

            Mesec = mesec;
            Grad = grad ?? throw new ArgumentNullException(nameof(grad));

            // potrosnja ne moze biti negativna
            if (zabelezenaPotrosnja < 0.0)
            {
                throw new ArgumentException();
            }

            ZabelezenaPotrosnja = zabelezenaPotrosnja;
        }

        public int UserId { get; set; }
        public int BrojiloId { get; set; }
        public int Mesec { get; set; }
        public string Grad { get; set; }
        public double ZabelezenaPotrosnja { get; set; }
        public override bool Equals(object obj)
        {
            return obj is EvidencijaPotrosnje potrosnja &&
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
