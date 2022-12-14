using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Konekcija
{
    public class DatabaseConnectionParams
    {
        public static readonly string LOCAL_DATA_SOURCE = "//localhost:1521/xe";
        public static readonly string E_DATA_SOURCE = "https://gitrebasexe.com:1521/xe";

        public static readonly string USER_ID = "ers_db";
        public static readonly string PASSWORD = "ers";
    }
}
