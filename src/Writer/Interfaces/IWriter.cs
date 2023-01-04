using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IWriter
    {
        void ProsledjivanjePodatakaUBafer(string userID, string username, string userAdress, string userCity,
                                          string brojiloId, decimal potroseno, string mesec);
    }
}
