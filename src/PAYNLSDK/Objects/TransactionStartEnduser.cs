using Newtonsoft.Json;
using PAYNLSDK.Enums;

namespace PAYNLSDK.Objects
{
    /// <summary>
    /// 
    /// </summary>
    public class TransactionStartEnduser
    {
        /// <summary>
        /// Indidicator whether or not the cusomer is blacklisted
        /// </summary>
        [JsonProperty("blacklist")]
        public Blacklist Blacklist {get; protected set;}
    }
}
