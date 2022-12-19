using System;

namespace Cache_Memory.Models
{
    public class KorisnikBrojilo
    {
        private int userId;
        private int brojiloId;

        public KorisnikBrojilo(int userId, int brojiloId)
        {
            if (userId < 1 || brojiloId < 1)
            {
                throw new ArgumentException();
            }

            UserId = userId;
            BrojiloId = brojiloId;
        }

        public int UserId { get => userId; set => userId = value; }
        public int BrojiloId { get => brojiloId; set => brojiloId = value; }

        public override bool Equals(object obj)
        {
            return obj is KorisnikBrojilo brojilo &&
                   UserId == brojilo.UserId &&
                   BrojiloId == brojilo.BrojiloId;
        }

        public override int GetHashCode()
        {
            int hashCode = -1402291626;
            hashCode = hashCode * -1521134295 + UserId.GetHashCode();
            hashCode = hashCode * -1521134295 + BrojiloId.GetHashCode();
            return hashCode;
        }
    }
}
