using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Common
{
    [DataContract]
    public class Podatak
    {
        [DataMember]
        public int Rbr { get; set; }

        [DataMember]
        public string KorisnickoIme { get; set; }

        [DataMember]
        public string Adresa { get; set; }

        [DataMember]
        public string Grad { get; set; }

        [DataMember]
        public int IdBrojila { get; set; }

        [DataMember]
        public decimal Potrosnja { get; set; }

        [DataMember]
        public string Mesec { get; set; }

        public Podatak()
        {
            // prazan konstruktor
        }

        public Podatak(int rbr, string korisnickoIme, string adresa, string grad, int idBrojila, decimal potrosnja, string mesec)
        {
            if (rbr <= 0)
                throw new ArgumentException(nameof(rbr));

            if (idBrojila <= 0)
                throw new ArgumentException(nameof(idBrojila));

            if (potrosnja < 0)
                throw new ArgumentException(nameof(potrosnja));

            Rbr = rbr;
            KorisnickoIme = korisnickoIme ?? throw new ArgumentNullException(nameof(korisnickoIme));
            Adresa = adresa ?? throw new ArgumentNullException(nameof(adresa));
            Grad = grad ?? throw new ArgumentNullException(nameof(grad));
            IdBrojila = idBrojila;
            Potrosnja = potrosnja;
            Mesec = mesec ?? throw new ArgumentNullException(nameof(mesec));

            // ne smeju biti prazna polja
            if (korisnickoIme.Trim().Equals(""))
                throw new ArgumentException(nameof(korisnickoIme));

            if (adresa.Trim().Equals(""))
                throw new ArgumentException(nameof(adresa));

            if (grad.Trim().Equals(""))
                throw new ArgumentException(nameof(grad));

            if (mesec.Trim().Equals(""))
                throw new ArgumentException(nameof(mesec));
        }

        public override bool Equals(object obj)
        {
            return obj is Podatak podatak &&
                   Rbr == podatak.Rbr &&
                   KorisnickoIme == podatak.KorisnickoIme &&
                   Adresa == podatak.Adresa &&
                   Grad == podatak.Grad &&
                   IdBrojila == podatak.IdBrojila &&
                   Potrosnja == podatak.Potrosnja &&
                   Mesec == podatak.Mesec;
        }

        public override int GetHashCode()
        {
            int hashCode = 419934427;
            hashCode = hashCode * -1521134295 + Rbr.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(KorisnickoIme);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Adresa);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Grad);
            hashCode = hashCode * -1521134295 + IdBrojila.GetHashCode();
            hashCode = hashCode * -1521134295 + Potrosnja.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Mesec);
            return hashCode;
        }
    }
}
