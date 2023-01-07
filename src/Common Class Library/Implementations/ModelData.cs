using System;

namespace Common_Class_Library.Implementations
{
    [Serializable]
    public class ModelData
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string UserAddress { get; set; }
        public string UserCity { get; set; }
        public string BrojiloId { get; set; }
        public decimal Potroseno { get; set; }
        public string Mesec { get; set; }

        public ModelData()
        {
        }

        public ModelData(int userID, string username, string userAddress, string userCity, string brojiloId, decimal potroseno, string mesec)
        {
            // ne smeju biti null
            if (username == null || userAddress == null || userCity == null || brojiloId == null || mesec == null)
            {
                throw new ArgumentNullException();
            }

            // ne smeju biti prazna polja
            if (userID < 1 || username.Trim().Equals("") || userAddress.Trim().Equals("") || userCity.Trim().Equals("") || brojiloId.Trim().Equals("") || mesec.Trim().Equals("") || potroseno < 0)
            {
                throw new ArgumentException();
            }

            UserID = userID;
            Username = username;
            UserAddress = userAddress;
            UserCity = userCity;
            BrojiloId = brojiloId;
            Potroseno = potroseno;
            Mesec = mesec;
        }

        public override bool Equals(object obj)
        {
            return obj is ModelData data &&
                   UserID == data.UserID &&
                   Username == data.Username &&
                   UserAddress == data.UserAddress &&
                   UserCity == data.UserCity &&
                   BrojiloId == data.BrojiloId &&
                   Potroseno == data.Potroseno &&
                   Mesec == data.Mesec;
        }
    }
}
