using System.Data;

namespace Common.Interfaces
{
    public interface IConnection
    {
        IDbConnection GetConnection();
    }
}
