using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Implementations
{
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
            UserID = userID;
            Username = username;
            UserAddress = userAddress;
            UserCity = userCity;
            BrojiloId = brojiloId;
            Potroseno = potroseno;
            Mesec = mesec;
        }
    }
}
