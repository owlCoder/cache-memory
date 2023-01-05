using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Implementations
{
    public class ModelData
    {               
        public string userID { get; set; }
        public string username { get; set; }
        public string userAddress { get; set; }
        public string userCity { get; set; }
        public string brojiloId { get; set; }
        public decimal potroseno { get; set; }
        public string mesec { get; set; }

        public ModelData()
        {
        }

        public ModelData(string userID, string username, string userAddress, string userCity, string brojiloId, decimal potroseno, string mesec)
        {
            this.userID = userID;
            this.username = username;
            this.userAddress = userAddress;
            this.userCity = userCity;
            this.brojiloId = brojiloId;
            this.potroseno = potroseno;
            this.mesec = mesec;
        }
    }
}
