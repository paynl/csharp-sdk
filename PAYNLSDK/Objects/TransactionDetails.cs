using System;
using Newtonsoft.Json;
using PAYNLSDK.Enums;
using PAYNLSDK.Converters;

namespace PAYNLSDK.Objects
{
    public class TransactionDetails
    {
        /// <summary>
        /// The scrambled id of the transaction.
        /// </summary>
        [JsonProperty("transactionId")]
        public string TransactionId { get; protected set; }

        /// <summary>
        /// The order id of the transaction.
        /// </summary>
        [JsonProperty("orderId")]
        public string OrderId { get; protected set; }

        /// <summary>
        /// The stats id of the transaction.
        /// </summary>
        [JsonProperty("statsId")]
        public string StatsId { get; protected set; }

        /// <summary>
        /// Payment Status indicator
        /// </summary>
        [JsonProperty("state")]
        public PaymentStatus? State { get; protected set; }

        /// <summary>
        /// Payment status name
        /// </summary>
        [JsonProperty("stateName")]
        public string StateName { get; protected set; }

        /// <summary>
        /// Start date of transaction
        /// </summary>
        [JsonProperty("startDate"), JsonConverter(typeof(YMDHISConverter))]
        public DateTime? StartDate { get; protected set; }

        /// <summary>
        /// Completed date of transaction
        /// </summary>
        [JsonProperty("completeDate"), JsonConverter(typeof(YMDHISConverter))]
        public DateTime? CompleteDate { get; protected set; }

        /// <summary>
        /// ID of the payment profile used to pay the transaction
        /// </summary>
        [JsonProperty("paymentProfileId")]
        public int? PaymentProfileId { get; protected set; }

        /// <summary>
        /// Name of the payment profile used to pay the transaction
        /// </summary>
        [JsonProperty("paymentProfileName")]
        public string PaymentProfileName { get; protected set; }

        /// <summary>
        /// Name of the consumer
        /// </summary>
        [JsonProperty("identifierName")]
        public string IdentifierName { get; protected set; }

        /// <summary>
        /// Type of customer ID
        /// </summary>
        [JsonProperty("identifierType")]
        public string IdentifierType { get; protected set; }

        /// <summary>
        /// Payment identifier that can be displayed to the customer for reference
        /// </summary>
        [JsonProperty("identifierPublic")]
        public string IdentifierPublic { get; protected set; }

        /// <summary>
        /// Customer ID, a unique hash based upon the bankaccount/creditcard number of the customer
        /// </summary>
        [JsonProperty("identifierHash")]
        public string IdentifierHash { get; protected set; }

        /// <summary>
        /// Amount of the session (in cents, eg. 1235)
        /// </summary>
        [JsonProperty("amount")]
        public CurrencyAmount Amount { get; protected set; }

    }
}
