using System;
using Newtonsoft.Json;
using PAYNLSDK.Enums;
using PAYNLSDK.Converters;

namespace PAYNLSDK.Objects
{
    /// <summary>
    /// Payment Transaction Information
    /// </summary>
    public class TransactionStats
    {
        /// <summary>
        /// Transaction identifier. 
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Name of the website used for the transaction
        /// </summary>
        [JsonProperty("websiteName")]
        public string WebsiteName { get; set; }

        /// <summary>
        /// Name of the service used for the transaction
        /// </summary>
        [JsonProperty("serviceName")]
        public string ServiceName { get; set; }

        /// <summary>
        /// Code of the service used for the transaction
        /// </summary>
        [JsonProperty("serviceCode")]
        public string ServiceCode { get; set; }

        /// <summary>
        /// Amount in cents of euro
        /// </summary>
        [JsonProperty("orderAmount")]
        public int OrderAmount { get; set; }

        /// <summary>
        /// Date and time of the transaction.
        /// </summary>
        [JsonProperty("created"), JsonConverter(typeof(YMDHISConverter))]
        public DateTime Created { get; set; }

        // TODO: this should be paymentstatus
        /// <summary>
        /// Internal status of the transaction
        /// </summary>
        [JsonProperty("internalStatus")]
        public int InternalStatus { get; set; }

        /// <summary>
        /// If Y mean that the payment was verified
        /// </summary>
        [JsonProperty("consumer3dsecure")]
        public string Consumer3dSecure { get; set; }

        /// <summary>
        /// Consumer account number
        /// </summary>
        [JsonProperty("consumerAccountNumber")]
        public string ConsumerAccountNumber { get; set; }

        /// <summary>
        /// ID of the Payment Profile used for this transaction
        /// </summary>
        [JsonProperty("profileId")]
        public int ProfileId { get; set; }

        /// <summary>
        /// Name of the Payment Profile used for this transaction
        /// </summary>
        [JsonProperty("profileName")]
        public string ProfileName { get; set; }

    }

    /// <summary>
    /// List of Transaction Statusses
    /// </summary>
    public class TransactionStatsList
    {
        /// <summary>
        /// Array containing the transactions stats
        /// </summary>
        [JsonProperty("transations")]
        public TransactionStats[] Transactions { get; set; }
    }

}
