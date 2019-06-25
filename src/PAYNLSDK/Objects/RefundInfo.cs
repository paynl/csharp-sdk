using System;
using Newtonsoft.Json;

namespace PAYNLSDK.Objects
{
    /// <summary>
    /// Refund Info Details
    /// </summary>
    public class RefundInfo
    {
        /// <summary>
        /// payment session ID
        /// </summary>
        [JsonProperty("paymentSessionId")]
        public int PaymentSessionId { get; protected set; }

        /// <summary>
        /// Refund amount
        /// </summary>
        [JsonProperty("amount")]
        public int Amount { get; protected set; }

        /// <summary>
        /// description
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; protected set; }

        /// <summary>
        /// The name of the customer.
        /// </summary>
        [JsonProperty("bankAccountHolder")]
        public string BankAccountHolder { get; set; }

        /// <summary>
        /// The bankaccount number of the customer.
        /// </summary>
        [JsonProperty("bankAccountNumber")]
        public string BankAccountNumber { get; set; }

        /// <summary>
        /// The BIC of the bank.
        /// </summary>
        [JsonProperty("bankAccountBic")]
        public string BankAccountBic { get; set; }

        /// <summary>
        /// status code
        /// </summary>
        [JsonProperty("statusCode")]
        public int StatusCode { get; protected set; }

        /// <summary>
        /// status description
        /// </summary>
        [JsonProperty("statusName")]
        public string StatusName { get; protected set; }

        /// <summary>
        /// The currency of the amount, default is EUR.
        /// </summary>
        [JsonProperty("processDate")]
        public DateTime? ProcessDate { get; set; }

    }
}
