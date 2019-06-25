using Newtonsoft.Json;

namespace PAYNLSDK.Objects
{
    /// <summary>
    /// Storno Details
    /// </summary>
    public class StornoDetails
    {
        /// <summary>
        /// ID of the refund
        /// </summary>
        [JsonProperty("stornoId")]
        public int? StornoId { get; protected set; }

        /// <summary>
        /// Refund amount
        /// </summary>
        [JsonProperty("stornoAmount")]
        public int? StornoAmount { get; protected set; }

        /// <summary>
        /// Number of the bankaccount the refund is deposited to
        /// </summary>
        [JsonProperty("bankAccount")]
        public string BankAccount { get; protected set; }

        /// <summary>
        /// IBAN of the bankaccount the refund is deposited to
        /// </summary>
        [JsonProperty("iban")]
        public string IBAN { get; protected set; }

        /// <summary>
        /// BIC of the bankaccount the refund is deposited to 
        /// </summary>
        [JsonProperty("bic")]
        public string bic { get; protected set; }

        /// <summary>
        /// City of the bankaccount owner 
        /// </summary>
        [JsonProperty("city")]
        public string City { get; protected set; }

        /// <summary>
        /// Date and time the payment is refunded 
        /// </summary>
        [JsonProperty("datetime")]
        public string Date { get; protected set; }

        /// <summary>
        /// Reason of the refund
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; protected set; }

        /// <summary>
        /// The email address the refund confirmation is sent to
        /// </summary>
        [JsonProperty("emailAdress")]
        public string EmailAddress { get; protected set; }
    }
}
