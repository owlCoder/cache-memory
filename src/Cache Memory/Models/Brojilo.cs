using System;
using System.Collections.Generic;

namespace Cache_Memory.Models
{
    public class Brojilo
    {
        private int id;
        private string naziv;

        public Brojilo(int id, string naziv)
        {
            Id = id;

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

        public int Id { get => id; set => id = value; }
        public string Naziv { get => naziv; set => naziv = value; }

        public override bool Equals(object obj)
        {
            return obj is Brojilo brojilo &&
                   Id == brojilo.Id &&
                   Naziv == brojilo.Naziv;
        }
        public override int GetHashCode()
        {
            int hashCode = -656151847;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Naziv);
            return hashCode;
        }
    }
}
