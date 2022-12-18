using System;
using System.Collections.Generic;
using System.Buffers;

namespace Cache_Memory.Models
{
    public class Brojilo
    {
        private int brojiloId;
        private string naziv;

        public Brojilo(int brojiloId, string naziv)
        {
            BrojiloId = brojiloId;

            if (naziv == null)
            {
                throw new ArgumentNullException();
            }

            if (naziv.Trim().Equals(string.Empty))
            {
                throw new ArgumentException();
            }

            Naziv = naziv;
        }

        public int BrojiloId { get => brojiloId; set => brojiloId = value; }
        public string Naziv { get => naziv; set => naziv = value; }

        public override bool Equals(object obj)
        {
            return obj is Brojilo brojilo &&
                   brojiloId == brojilo.brojiloId &&
                   Naziv == brojilo.Naziv;
        }
        public override int GetHashCode()
        {
            int hashCode = -656151847;
            hashCode = hashCode * -1521134295 + brojiloId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Naziv);
            return hashCode;
        }
    }
}
