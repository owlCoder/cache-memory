using System.Collections.Generic;

namespace UBP_Template.Models
{
    public class Brojilo
    {
        public int BrojiloId { get; set; }
        public string Naziv { get; set; }

        public Brojilo(int brojiloId, string naziv)
        {
            BrojiloId = brojiloId;
            Naziv = naziv;
        }
        public override bool Equals(object obj)
        {
            return obj is Brojilo brojilo &&
                   BrojiloId == brojilo.BrojiloId &&
                   Naziv == brojilo.Naziv;
        }
        public override int GetHashCode()
        {
            int hashCode = 1151874800;
            hashCode = hashCode * -1521134295 + BrojiloId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Naziv);
            return hashCode;
        }

        public static string GetFormatedHeader()
        {
            return string.Format("{0, -10} {1, -30}", "Brojilo_Id", "Naziv");
        }
        public override string ToString()
        {
            return string.Format("{0, -10} {1, -30}", BrojiloId, Naziv);
        }
    }
}
