using Common.Interfaces;
using System;
using System.Data;

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
