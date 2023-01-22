using System;
using System.Collections.Generic;

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
            // prazan konstruktor
        }

        public ModelData(int userID, string username, string userAddress, string userCity, string brojiloId, decimal potroseno, string mesec)
        {
            // ne smeju biti null
            CheckNullArguments(username, userAddress, userCity, brojiloId, mesec);

            // ne smeju biti prazna polja
            CheckEmptyArguments(userID, username, userAddress, userCity, brojiloId, potroseno, mesec);

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

        public override int GetHashCode()
        {
            int hashCode = 994044566;
            hashCode = hashCode * -1521134295 + UserID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Username);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UserAddress);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UserCity);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(BrojiloId);
            hashCode = hashCode * -1521134295 + Potroseno.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Mesec);
            return hashCode;
        }

        private static void CheckNullArguments(string username, string userAddress, string userCity, string brojiloId, string mesec)
        {
            if (username == null || userAddress == null || userCity == null || brojiloId == null || mesec == null)
            {
                throw new ArgumentNullException();
            }
        }

        private static void CheckEmptyArguments(int userID, string username, string userAddress, string userCity, string brojiloId, decimal potroseno, string mesec)
        {
            if (userID < 1 || username.Trim().Equals("") || userAddress.Trim().Equals("") || userCity.Trim().Equals("") || brojiloId.Trim().Equals("") || mesec.Trim().Equals("") || potroseno < 0)
            {
                throw new ArgumentException();
            }
        }
    }
}
