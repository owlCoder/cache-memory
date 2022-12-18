namespace Cache_Memory.Connection
{
    public class ConnectionParameters
    {
#if DEBUG
        // LOCAL DEVELOPEMENT
        public static readonly string DATA_SOURCE = "//localhost:1521/xe";
        public static readonly string USER_ID = "ers_db";
        public static readonly string PASSWORD = "ers";
#else
                // AZURE DATABASE
                public static readonly string DATA_SOURCE = "https://portal.azure.com/oracle/xe:1521/cache-memory5114";
                public static readonly string USER_ID = "sysdba_azure";
                public static readonly string PASSWORD = "43JK#d65260";
#endif
    }
}
