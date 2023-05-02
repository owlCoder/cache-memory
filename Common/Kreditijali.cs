using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Common
{
    [ExcludeFromCodeCoverage]
    [DataContract]
    public class Kreditijali
    {
        [DataMember]
        public static readonly string LOCAL_DATA_SOURCE = "//localhost:1521/xe";

        [DataMember]
        public static readonly string USER_ID = "ers";

        [DataMember]
        public static readonly string PASSWORD = "ers";
    }
}
