namespace Database.Modeli
{
    public class Brojilo
    {
        private int id;
        private int naziv;

        public Brojilo(int id, int naziv)
        {
            Id = id;
            Naziv = naziv;
        }

        public int Id { get => id; set => id = value; }
        public int Naziv { get => naziv; set => naziv = value; }
    }
}
