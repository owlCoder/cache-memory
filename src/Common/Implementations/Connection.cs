using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Implementations
{
    public class Connection : IConnection
    {
        public IDbConnection GetConnection()
        {
            throw new NotImplementedException(); // BK
        }
    }
}
