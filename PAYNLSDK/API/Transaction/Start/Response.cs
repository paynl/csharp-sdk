using System;
using Newtonsoft.Json;
using PAYNLSDK.Objects;

namespace PAYNLSDK.API.Transaction.Start
{
    public class Response : ResponseBase
    {
        /// <summary>
        /// Information about the enduser
        /// </summary>
        [JsonProperty("endUser")]
        public Enduser EndUser { get; set; }
        /// <summary>
        /// The <see cref="TransactionData"/> for the started tranaction.  Containing the url and transactionId
        /// </summary>
        [JsonProperty("transaction")]
        public TransactionData Transaction { get; set; }

        public class Enduser
        {
            public string blacklist { get; set; }
        }

        public class TransactionData
        {
            [JsonProperty("transactionId")]public string TransactionId { get; set; }
            [JsonProperty("paymentURL")] public string PaymentUrl { get; set; }
            [JsonProperty("popupAllowed")] public string PopupAllowed { get; set; }
            [JsonProperty("paymentReference")] public string PaymentReference { get; set; }
        }

    }
}

