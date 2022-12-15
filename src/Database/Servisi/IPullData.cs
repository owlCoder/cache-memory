using System.Data;

namespace Database.Servisi
{
    public interface IPullData
    {
        IDbConnection Baza { get; set; }
        IDbCommand Command { get; set; }
        IDataReader Reader { get; set; }

        bool GetTargetedDataFromDatabase(int Id, string sql);
    }
}
