namespace Common.Interfaces
{
    public interface IWriter
    {
        void ProsledjivanjePodatakaUBafer(string userID, string username, string userAdress, string userCity,
                                          string brojiloId, decimal potroseno, string mesec);
    }
}
