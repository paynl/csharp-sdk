using Newtonsoft.Json;
using System;

namespace PAYNLSDK.Objects
{
    /// <summary>
    /// General Statistics details.
    /// These can be used to track your own statistics on transactions and will be returned when Transaction Info is requested.
    /// </summary>
    public class StatsDetails
    {
        /// <summary>
        /// ID for the Payment session these details belong to
        /// </summary>
        [JsonProperty("paymentSessionId")]
        public int? PaymentSessionId { get; set; }

        /// <summary>
        /// The used tool code which can be tracked in the stats
        /// </summary>
        [JsonProperty("tool")]
        public string Tool { get; set; }

        /// <summary>
        /// The used info code which can be tracked in the stats
        /// </summary>
        [JsonProperty("info")]
        public string Info { get; set; }

        /// <summary>
        /// The id of a promotor / affiliate.
        /// In general, you won't use this unless you know the ID's of your affiliate's
        /// </summary>
        [JsonProperty("promotorId")]
        public int? PromotorId { get; set; }

        /// <summary>
        /// The first free value which can be tracked in the stats
        /// </summary>
        [JsonProperty("extra1")]
        public string Extra1 { get; set; }

        /// <summary>
        /// The second free value which can be tracked in the stats
        /// </summary>
        [JsonProperty("extra2")]
        public string Extra2 { get; set; }

        /// <summary>
        /// The third free value which can be tracked in the stats
        /// </summary>
        [JsonProperty("extra3")]
        public string Extra3 { get; set; }

        /// <summary>
        /// Option to send multiple values via an array which can be tracked in the stats
        /// </summary>
        [JsonProperty("transferData")]
        public string[] TransferData { get; set; }
    }

}
