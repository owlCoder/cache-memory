using System;

namespace Database.Modeli
{
    public class Brojilo
    {
        private int id;
        private string naziv;

        public Brojilo(int id, string naziv)
        {
            Id = id;

            if(naziv == null)
            {
                throw new ArgumentNullException();
            }

            if(naziv.Trim().Equals(string.Empty))
            {
                throw new ArgumentException();
            }

            Naziv = naziv;
        }

        public int Id { get => id; set => id = value; }
        public string Naziv { get => naziv; set => naziv = value; }
    }
}
