using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpingBuffer.Interfaces
{
    public interface IDumpingBuffer
    {
        void AddToQueue(string userID, string username, string userAddress, string userCity,
                        string brojiloId, decimal potroseno, string mesec);
    }
}
