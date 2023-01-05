using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Implementations
{
    public class ModelData
    {               
        string userID { get; set; }
        string username { get; set; }
        string userAddress { get; set; }
        string userCity { get; set; }
        string brojiloId { get; set; }
        decimal potroseno { get; set; }
        string mesec { get; set; }

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
