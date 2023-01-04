using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Implementations
{
    public class Writer : IWriter
    {
        // private DumpingBuffer dumpingBuffer = new DumpingBuffer();
        public void ProsledjivanjePodatakaUBafer(string userID, string username, string userAddress, string userCity, 
                                                 string brojiloId, decimal potroseno, string mesec)
        {
            throw new NotImplementedException(); // BK
            // dumping.buffer.AddToQueue(podaci);
        }
    }
}
