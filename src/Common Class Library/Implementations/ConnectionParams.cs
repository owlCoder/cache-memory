using System.Diagnostics.CodeAnalysis;

namespace Common_Class_Library.Implementations
{
    [ExcludeFromCodeCoverage]
    public class ConnectionParams
    {
        public static readonly string LOCAL_DATA_SOURCE = "//localhost:1521/xe";
        public static readonly string USER_ID = "ers_db";
        public static readonly string PASSWORD = "ers";
    }
}
