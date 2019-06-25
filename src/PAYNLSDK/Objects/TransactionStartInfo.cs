using System;
using Newtonsoft.Json;
using PAYNLSDK.Enums;
using PAYNLSDK.Converters;

namespace PAYNLSDK.Objects
{
    /// <summary>
    /// Transaction Start Information object.
    /// This object is part of the response returned after a call to start a transaction and contains the 
    /// transaction ID and payment URL you should redirect the enduser to.
    /// </summary>
    public class TransactionStartInfo
    {
        /// <summary>
        /// Transaction ID
        /// </summary>
        [JsonProperty("transactionId")]
        public string TransactionId { get; protected set; }

        /// <summary>
        /// The URL where the customer can be send to in order to finish the transaction. 
        /// </summary>
        [JsonProperty("paymentURL")]
        public string PaymentURL { get; protected set; }

        /// <summary>
        /// Indicates whether the payment screen may be loaded in popup window
        /// </summary>
        [JsonProperty("popupAllowed"), JsonConverter(typeof(BooleanConverter))]
        public bool? PopupAllowed { get; protected set; }

        /// <summary>
        /// Payment reference used to identify manual bank transfers
        /// </summary>
        [JsonProperty("paymentReference")]
        public string PaymentReference { get; protected set; }

    }
}
